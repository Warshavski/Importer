using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;

namespace Importer.Engine.Models
{
    public class DbfFile : IFile
    {
        // name of data provider
        private const string PROVIDER_NAME = "System.Data.OleDb";

        public DbfFile(string dataSource, PropertyInfo property)
        {
            /* *.dbf connection string
             *  @"Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0}; User ID=Admin; Password=; Extended Properties={1};"
             */

            // hmmmm... think for better way to construct connection string at all
            OleDbConnectionStringBuilder connectionBuilder = new OleDbConnectionStringBuilder();
            connectionBuilder.DataSource = dataSource;
            connectionBuilder.Provider = "Microsoft.Jet.OLEDB.4.0";
            connectionBuilder.Add("User ID", "Admin");
            connectionBuilder.Add("Extended Properties", property.Value);

            _connectionString = connectionBuilder.ConnectionString;
            
            _tableList = null;
        }

        #region Члены IFile

        private string _connectionString = string.Empty;
        public string ConnectionString
        {
            get { return _connectionString; }
        }

        private List<Table> _tableList = null;
        public List<Table> TableList
        {
            get { return _tableList; }
        }

        public bool TestConnection()
        {
            try
            {
                // trying to create connection
                using (var connection = DataAccess.CreateDbConnection(PROVIDER_NAME, _connectionString))
                {
                    // trying to open connection
                    connection.Open();
                    // trying to close connection
                    connection.Close();
                    // return connection is valid
                    return true;
                }
            }
            // catch DbException
            catch (DbException)
            {
                // return connection is not valid
                return false;
            }
        }

        public void InitializeTables(bool isSource)
        {
            // create OleDbConnection 
            using (DbConnection connection = DataAccess.CreateDbConnection(PROVIDER_NAME, _connectionString))
            {
                // initialize base SourceTable collection
                // create link to empty List<SourceTable>
                _tableList = new List<Table>();

                connection.Open();
                
                _tableList.Add(Table.EmptyTable);

                // get information about tables from connection schema 
                DataTable dtTables = connection.GetSchema("Tables");
                // initialization of OleDbTable class and add it into table collection
                foreach (DataRow dtTablesRow in dtTables.Rows)
                    _tableList.Add(new Table((string)dtTablesRow["TABLE_NAME"], connection, PROVIDER_NAME, isSource));
                connection.Close();

                // disposing DataTable that contains information about tables
                dtTables.Dispose();
                dtTables = null;
            }
        }

        #endregion
    }
}

/*  DBF Header
 * +----------+--------+------------------------------------+
 * | Address  | Length | Description                        |
 * +----------+--------+------------------------------------+
 * 0    0x00  (1)      Version
 * 1    0x01  (3)      Last modification date (YYMMDD)
 * 4    0x04  (4)      Records number
 * 8    0x08  (2)      Header length
 * 10   0x0A  (2)      Record length
 * 12   0x0C  (2)      Reserved always 0
 * 14   0x02  (1)      Flag, incomplete transaction
 * 15   0x0F  (1)      Flag, dBASE IV encription 
 * 16   0x10  (12)     Reserved area
 * 28   0x1C  (1)      Flag, MDX-file
 * 29   0x1D  (1)      Code page ID
 * 30   0x1E  (2)      Reserved always 0
 * 32   0x20  (32)     Language ariver ID (dBASE 7 only)
 * 64   0x40  (4)      Reserved (dBASE 7 only)
 */

/*  Field Descriptor (except dBASE 7)
 * +---------+--------+-------------------------+
 * | Address | Length | Assignment              |
 * +---------+--------+-------------------------+
 *  0   0x00  (11)     Field name
 *  11  0x0B  (1)      Field type
 *  12  0x0C  (4)      Reserved 
 *  16  0x10  (1)      Full field length
 *  17  0x11  (1)      Decimal
 *  30  0x1E  (13)     Reserved
 *  31  0x1F  (1)      MDX-file tag (dBASE IV)
 */

/*  Field Descriptor (dBASE 7)
 * +---------+--------+-----------------------------------------------------+
 * | Address | Length | Assignment                                          |
 * +---------+--------+-----------------------------------------------------+
 *  0   0x00   (32)    Field name
 *  32  0x20   (1)     Field type
 *  33  0x21   (1)     Full field length
 *  34  0x22   (1)     Decimal
 *  35  0x23   (2)     Reserved
 *  37  0x25   (1)     MDX-file tag : 1 - indexed field, 0 - non indexed
 *  38  0x26   (2)     Reserved
 *  40  0x28   (4)     Auto increment
 *  44  0x2C   (4)     Reserved
 */

/*  Fields Type
 * +------+---------------------+-------------------+
 * | Char | Type Name           | Released          |
 * +------+---------------------+-------------------+
 *  B      Binary                dBASE 5
 *         Double                MS Visual FoxPro
 *  C      Character             dBASE III
 *  D      Date                  dBASE III
 *  F      Float                 dBASE IV
 *  G      General(OLE)          dBASE 5
 *  I      Integer(Long)         dBASE 7
 *  L      Logical               dBASE III
 *  M      Memo                  dBASE III
 *  N      Numeric               dBASE III
 *  O      Double                dBASE 7
 *  P      Picture               FoxPro
 *  Q      Varbinary             MS Visual FoxPro
 *  T      DateTime              FoxPro
 *  V      Varchar               MS Visual FoxPro
 *  W      Blob                  MS Visual FoxPro
 *  Y      Currency              MS Visual FoxPro
 *  @      Timestamp(DateTime)   dBASE 7
 *  +      Autoincrement         dBASE 7
 */

/*  Encoding table
 * +--------+-------------+-----------------------------------+
 * |  Byte  |  Page Code  |  Encoding                         |
 * +--------+-------------+-----------------------------------+
 *   0x01      427           DOS USA code page 437 
 *   0x02      850           DOS Multilingual code page 850 
 *   0x03      1252          Windows ANSI code page 1252
 *   0x04      10000         Standard Macintosh
 *   0x08      865           Danish OEM
 *   0x13      932           Japanese Shift-JIS
 *   0x1C      863           French OEM (Canada)
 *   0x1F      852           Czech OEM
 *   0x24      860           Portuguese OEM
 *   0x4D      936           Chinese GBK (PRC)
 *   0x4E      949           Korean (ANSI/OEM)
 *   0x4F      950           Chinese Big5 (Taiwan)
 *   0x50      874           Thai (ANSI/OEM)
 *   0x67      861           Icelandic MS–DOS
 *   0x68      895           Kamenicky (Czech) MS-DOS
 *   0x69      620           Mazovia (Polish) MS-DOS
 *   0x6A      737           Greek MS–DOS (437G)
 *   0x6B      857           Turkish MS–DOS
 *   0x7D      1255          Hebrew Windows
 *   0x7E      1256          Arabic Windows
 *   0x96      10007         Russian Macintosh
 *   0x97      10029         Eastern European Macintosh
 *   0x98      10006         Greek Macintosh 
 *   0xC8      1250          Eastern European Windows
 *   0xCA      1254          Turkish Windows
 *   0xCB      1253          Greek Windows
 *   0xCC      1257          Baltic Windows
 *   0x26      866           Russian DOS
 *   0x87      1251          Russian Windows
 */