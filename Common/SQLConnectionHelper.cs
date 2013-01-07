using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Collections;
using System.Data.Sql;
using System.Data;
using System.Data.SqlClient;

namespace ITSharp.ScheDEX.Common
{
    public class SQLConnectionHelper
    {
        public event EventHandler<SQLConnectionEventArgs> ConnectionEvent;
        public event EventHandler<SQLConnectionEventArgs> DisconnectionEvent;
        public event EventHandler ServerNamesHasBeenFetched;
        public event EventHandler DatabasesHasBeenFetched;
        public event EventHandler TablesHasBeenFetched;

        private ArrayList serverNames;
        private String defaultServerName;
        private SQLConnectionString sqlConnectionStr;
        private Boolean isConnected;
        private SqlConnection sqlConnection;
        private ArrayList databases;
        private String defaultDatabase;
        private ArrayList tables;
        private Dictionary<String, String> queries;

        private string query_kartoteki = @"SELECT
	[Magazyny].[mag_kod] AS [Magazyn],
	[Oferta].[ofr_symbol] AS [Symbol],
	[Oferta].[ofr_nazwa] AS [Nazwa],
	[Oferta].[ofr_ilosc] AS [Stan magazynowy],
	[Oferta].[ofr_ilosc]-[Oferta].[ofr_rezerwacje] AS [Ilość do dyspozycji],
	[Jednostki].[jdn_kod] AS [Jm],
	[CENA_DETALICZNA].[ofc_cena] AS [Cena],
	[ONTHEFLY].[ostatnia_cena] AS [Ostatnia cena zakupu],
	[Oferta].[ofr_cena_min] AS [Cena minimalna],
	[Vat].[vat_stawka] AS [Vat],
	[Oferta].[ofr_waga] AS [Waga],
	[Oferta].[ofr_pkwiu] AS [PKWiU],
	[Oferta].[ofr_sww] AS [SWW],
	[Lokalizacje].[lok_nazwa] AS [Lokalizacja],
	[Producenci].prd_nazwa AS [Producent],
	[GrupyOfr].[grf_nazwa] AS [Grupa],
	[OfertaBarkody].[ofb_kod] AS [Kod]
FROM 
	[Oferta]
LEFT JOIN
	[Magazyny] ON [Oferta].[ofr_magazyn] = [Magazyny].[mag_id]
LEFT JOIN
	[Jednostki] ON [Oferta].[ofr_jednostka] = [Jednostki].[jdn_id]
LEFT JOIN
	[Producenci] ON [Oferta].[ofr_producent] = [Producenci].[prd_id]
LEFT JOIN
	[GrupyOfr] ON [Oferta].[ofr_grupa] = [GrupyOfr].[grf_id]
LEFT JOIN
    [Lokalizacje] ON [Oferta].[ofr_lokalizacja] = [Lokalizacje].[lok_id]
LEFT JOIN
	[Vat] ON [Oferta].[ofr_vat] = [Vat].[vat_id]
LEFT JOIN
	[OfertaBarkody] ON [Oferta].[ofr_symbol] = [OfertaBarkody].[ofb_ofr_symbol]
LEFT JOIN -- Ostatnia cena
	(
	SELECT  [TransPrzychody].[trp_ofr] AS ofreta_id, 
			[TransPrzychody].[trp_data] AS ostatnia_data,
			[TransPrzychody].[trp_cena] AS ostatnia_cena
	FROM [TransPrzychody] 
	INNER JOIN
		(
		SELECT [trp_ofr], MAX([trp_id]) AS _id
		FROM [TransPrzychody] 
		GROUP BY [trp_ofr]
		) MAX_DATA
		ON ([TransPrzychody].[trp_ofr] = [MAX_DATA].[trp_ofr] AND [TransPrzychody].[trp_id] = [MAX_DATA].[_id])
	) [ONTHEFLY]
	ON [ONTHEFLY].[ofreta_id] = [Oferta].[ofr_id]

LEFT JOIN -- Cena detaliczna
	(
	SELECT  [ofc_ofr], 
			[ofc_cena]
	FROM [OfertaCeny]
	WHERE [OfertaCeny].[ofc_rodzaj] = 1
	) CENA_DETALICZNA
	ON [Oferta].[ofr_id] = [CENA_DETALICZNA].[ofc_ofr];";
//WHERE 
//    [Magazyny].[mag_kod] = 'NAV';";

        private string query_kontrahenci = @"SELECT
	[Kontrahenci].[knt_id] AS [Id],
	[Kontrahenci].[knt_kod] AS [Kod],
	[Kontrahenci].[knt_nazwa] AS [Nazwa],
	[Kontrahenci].[knt_nip] AS [NIP],
	[Kontrahenci].[knt_email] AS [Email],
	[Kontrahenci].[knt_kredyt] AS [Limit kredytowy],
	[Kontrahenci].[knt_konto_ma]-[Kontrahenci].[knt_konto_wn] AS [Aktualny stan konta]
FROM 
	[Kontrahenci];";


        public SQLConnectionHelper()
        {
            this.serverNames = new ArrayList();
            this.defaultServerName = "";
            this.sqlConnectionStr = new SQLConnectionString();
            this.isConnected = false;
            this.sqlConnection = null;
            this.databases = new ArrayList();
            this.tables = new ArrayList();

            this.queries = new Dictionary<String, String>();
            this.queries.Add("Kartoteki", query_kartoteki);
            this.queries.Add("Dane klientów", query_kontrahenci);
        }

        public void StartScanServerNames()
        {
            Thread thread = new Thread(new ThreadStart(ScanServerNames));
            thread.Name = "ScanServerNames";
            thread.Start();
        }

        private void ScanServerNames()
        {
            this.serverNames.Clear();
            this.defaultServerName = "";
            this.isConnected = false;

            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            DataTable table = instance.GetDataSources();

            foreach (System.Data.DataRow row in table.Rows)
            {
                if (this.defaultServerName.Equals(""))
                {
                    this.defaultServerName = row["ServerName"] + "\\" + row["InstanceName"];
                }
                else
                {
                    if (!row["InstanceName"].Equals("SQLEXPRESS"))
                    {
                        this.defaultServerName = row["ServerName"] + "\\" + row["InstanceName"];
                    }
                }
                this.serverNames.Add(row["ServerName"] + "\\" + row["InstanceName"]);
            }

            this.sqlConnectionStr.Server = this.defaultServerName;
            this.sqlConnectionStr.Authentication = true;

            if (ServerNamesHasBeenFetched != null)
                ServerNamesHasBeenFetched(this, EventArgs.Empty);
        }

        public void StartConnect()
        {
            Thread thread = new Thread(new ThreadStart(ConnectByThread));
            thread.Name = "Connect";
            thread.Start();
        }

        public void Connect()
        {
            this.sqlConnection = new SqlConnection(this.sqlConnectionStr.ConnectionString);
            this.sqlConnection.Open();
            this.isConnected = true;
        }

        private void ConnectByThread()
        {
            try
            {
                this.sqlConnection = new SqlConnection(this.sqlConnectionStr.ConnectionString);
                this.sqlConnection.Open();
                this.isConnected = true;
                if (ConnectionEvent != null)
                    ConnectionEvent(this, SQLConnectionEventArgs.Success);
            }
            catch (Exception)
            {
                if (ConnectionEvent != null)
                    ConnectionEvent(this, SQLConnectionEventArgs.Fail);
            }
        }

        public void Disconnect()
        {
            if (this.isConnected)
            {
                this.sqlConnection.Close();
                this.isConnected = false;
            }
            if (DisconnectionEvent != null)
                DisconnectionEvent(this, SQLConnectionEventArgs.Success);
        }

        public void StartScanDatabases()
        {
            Thread thread = new Thread(new ThreadStart(ScanDatabases));
            thread.Name = "ScanDatabases";
            thread.Start();
        }

        private void ScanDatabases()
        {
            this.databases.Clear();

            if (this.isConnected)
            {
                DataTable tblDatabases = this.sqlConnection.GetSchema("Databases");

                foreach (DataRow rowDBs in tblDatabases.Rows)
                {
                    this.databases.Add(rowDBs["database_name"]);
                    this.defaultDatabase = rowDBs["database_name"].ToString();
                }
            }

            if (DatabasesHasBeenFetched != null)
                DatabasesHasBeenFetched(this, EventArgs.Empty);
        }

        public void StartScanTables()
        {
            Thread thread = new Thread(new ThreadStart(ScanTables));
            thread.Name = "ScanTables";
            thread.Start();
        }

        private void ScanTables()
        {
            this.tables.Clear();

            if (this.isConnected)
            {
                DataTable tblTables = this.sqlConnection.GetSchema("Tables");

                foreach (DataRow rowDBs in tblTables.Rows)
                {
                    this.tables.Add(rowDBs["table_name"]);
                }
            }

            if (TablesHasBeenFetched != null)
                TablesHasBeenFetched(this, EventArgs.Empty);
        }

        public ArrayList ServerNames
        {
            get { return this.serverNames; }
            set { this.serverNames = value; }
        }

        public String DefaultServerName
        {
            get { return this.defaultServerName; }
            set { this.defaultServerName = value; }
        }

        public ArrayList Databases
        {
            get { return this.databases; }
            set { this.databases = value; }
        }

        public String DefaultDatabase
        {
            get { return this.defaultDatabase; }
            set { this.defaultDatabase = value; }
        }

        public ArrayList Tables
        {
            get { return this.tables; }
            set { this.tables = value; }
        }

        public Dictionary<String, String> Queries
        {
            get { return this.queries; }
        }

        public SQLConnectionString ConnectionString
        {
            get { return this.sqlConnectionStr; }
            set { this.sqlConnectionStr = value; }
        }

        public Boolean IsConnected
        {
            get { return this.isConnected; }
        }

        public SqlConnection Connection
        {
            get { return this.sqlConnection; }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class SQLConnectionEventArgs : EventArgs
    {
        private Boolean isSuccess;
        public Boolean IsSuccess
        {
            get { return this.isSuccess; }
            set { this.isSuccess = value; }
        }

        public static SQLConnectionEventArgs Success
        {
            get
            {
                SQLConnectionEventArgs args = new SQLConnectionEventArgs();
                args.IsSuccess = true;
                return args;
            }
        }

        public static SQLConnectionEventArgs Fail
        {
            get
            {
                SQLConnectionEventArgs args = new SQLConnectionEventArgs();
                args.IsSuccess = false;
                return args;
            }
        }
    }
}
