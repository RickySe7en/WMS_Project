using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Data;
using System.Data.Linq;
using System.Data.Linq.SqlClient;
using System.Reflection;
using System.Data.Linq.Mapping;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Controls;

namespace WMS_Project_TM_Store_IT
{
    static public class CONNECTION
    {
        static public DataBaseHandler DbHandle;
        static public string conn = "Integrated Security=true;Initial Catalog=WMS_Project_TM_Store_IT;Data Source=.\\SQLExpress";
    }

    public partial class DataBaseHandler
    {
        #region Field
        private string username = string.Empty;
        private string password = string.Empty;
        #endregion Field

        #region Property
        public string Password
        {
            get { return password; }
            set { password = value; }
        }

        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        #endregion Property

        public bool DB_Query_Result()
        {
            //Initial Catalog needs to be assigned by the name of database
            //Data Source is the URI

            using (WMS_Project_DB db = new WMS_Project_DB(CONNECTION.conn))
            {


                var dataQuery = (from o in db.DataBaseUsers
                                 where String.Equals(o.UserName, this.username)
                                 where String.Equals(o.UserPassword, this.Password) //needs to encrypt in the end
                                 select o).FirstOrDefault();

                
                if (dataQuery == null)
                {
                    return false;
                }
                else
                    return true;
            }           
        }      
    }

    public class INV_Query
    {
        #region Field
        private int tableRow;
        private int tableColumn;
        private List<string> branchList;
        private List<string> ownerList;
        private bool isFirstTime = true;
        private bool showZero = false;
        #endregion

        #region Property
        public int TableRow
        {
            get { return tableRow; }
            set { tableRow = value; }
        }
        public int TableColumn
        {
            get { return tableColumn; }
            set { tableColumn = value; } 
        }
        public List<string> BranchList
        {
            get { return branchList; }
        }
        public List<string> OwnerList
        {
            get { return ownerList; }
        }
        public bool IsFirstTime
        {
            get { return isFirstTime; }
            set { isFirstTime = value; }
        }
        public bool ShowZero
        {
            get { return showZero; }
            set { showZero = value; }
        }
        #endregion

        //fill table
        public List<DataBaseSOH> INV_Table_Query(
            string branchFilter, 
            string ownerFilter,
            string proFilter,
            string locFilter,
            bool showZero)
        {
            //Initial Catalog needs to be assigned by the name of database
            //Data Source is the URI

            float lowerBound = (showZero == true) ? -1 : 0; //set lower bound for query
                                                            //showZero then > -1, else > 0

            using (WMS_Project_DB db = new WMS_Project_DB(CONNECTION.conn))
            {

                List<DataBaseSOH> queryList = db.DataBaseSOHs.ToList();

                List<DataBaseSOH> dataQuery;

                //setup filter
                if (isFirstTime)
                {
                    branchList = (from o in db.DataBaseSOHs.ToList()
                                  select o.Branch).Distinct().ToList();
                    ownerList = (from o in db.DataBaseSOHs.ToList()
                                 select o.Owner).Distinct().ToList();
                }

                if (!String.Equals("All", branchFilter) && !String.Equals("All", ownerFilter))
                {
                    dataQuery = (from o in queryList
                                    where o.QTY > lowerBound
                                    where String.Equals(o.Branch, branchFilter)
                                    where String.Equals(o.Owner, ownerFilter)
                                    where o.Location.StartsWith(locFilter)
                                    where o.ProductCode.StartsWith(proFilter)
                                    orderby o.Location
                                    select o).ToList();
                    return dataQuery;
                }
                else if (String.Equals("All", branchFilter) && !String.Equals("All", ownerFilter))
                {
                    dataQuery = (from o in queryList
                                    where o.QTY > lowerBound
                                    where String.Equals(o.Owner, ownerFilter)
                                    where o.Location.StartsWith(locFilter)
                                    where o.ProductCode.StartsWith(proFilter)
                                    orderby o.Location
                                    select o).ToList();
                    return dataQuery;
                }
                else if (!String.Equals("All", branchFilter))
                {
                    dataQuery = (from o in queryList
                                 where o.QTY > lowerBound
                                 where String.Equals(o.Branch, branchFilter)
                                 where o.Location.StartsWith(locFilter)
                                 where o.ProductCode.StartsWith(proFilter)
                                 //where o.Location.Contains(locFilter)
                                 //where o.ProductCode.Contains(proFilter)
                                 orderby o.Location
                                 select o).ToList();

                    return dataQuery;
                }
                else
                {
                    dataQuery = (from o in queryList
                                 where o.QTY > lowerBound
                                 where o.Location.StartsWith(locFilter)
                                 where o.ProductCode.StartsWith(proFilter)
                                 //where o.Location.Contains(locFilter)
                                 //where o.ProductCode.Contains(proFilter)
                                 orderby o.Location
                                 select o).ToList();
                    return dataQuery;
                }
                
            }
        }   
    }

    #region DataBaseDefinition
    [Table(Name = "dbo.User")]
    public class DataBaseUser
    {
        [Column(CanBeNull = false)]
        public string RecordIdentifier { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string UserID { get; set; }

        [Column(CanBeNull = false)]
        public string UserName { get; set; }

        [Column(CanBeNull = false)]
        public string UserPassword { get; set; }

        [Column(CanBeNull = false)]
        public string UserGroup { get; set; }
    }

    [Table(Name = "dbo.SOH")]
    public class DataBaseSOH
    {

        [Column(CanBeNull = false)]
        public string RecordIdentifier { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string Branch { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string Owner { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string ProductCode { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string Colour { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string Size { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string Location { get; set; }

        [Column(CanBeNull = false)]
        public string UOM { get; set; }

        //dispute real is like float but mostly integer
        [Column(CanBeNull = false)]
        public float QTY { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public DateTime ArrivalDate { get; set; }

        [Column(CanBeNull = true)]
        public string BatchNumber { get; set; }

        [Column(CanBeNull = true)]
        public string ExpiryDate { get; set; }

        [Column(CanBeNull = true)]
        public string SerialNumber { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute1 { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute2 { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute3 { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute4 { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute5 { get; set; }

        [Column(CanBeNull = true)]
        public string StockStatus { get; set; }

        public string Arrival
        {
            get
            {
                return ArrivalDate.ToString("yyyy-MM-dd");
            }
        }

        public static void AddDataBaseSOH(DataBaseSOH entrySOH, DataBaseTranHistory newTrans)
        {
            using (WMS_Project_DB db = new WMS_Project_DB(CONNECTION.conn))
            {
                db.DataBaseSOHs.InsertOnSubmit(entrySOH);
                DataBaseTranHistory.addNewTransHistoryEntry(newTrans, db);
            }
        }

        public static void UpdateDataBaseSOH(DataBaseSOH entrySOH, DataBaseTranHistory newTrans)
        {
            //DataContext db = new DataContext(connection);

            //Table<DataBaseSOH> DataBaseSOHs = db.GetTable<DataBaseSOH>();

            entrySOH.Location = entrySOH.Location.ToUpper();
            newTrans.Location = newTrans.Location.ToUpper();

            using (WMS_Project_DB db = new WMS_Project_DB(CONNECTION.conn))
            {
                try
                {
                    
                    DataBaseSOH dbSOH = db.DataBaseSOHs.Single(o =>
                                 o.Branch.Equals(entrySOH.Branch)
                                 && o.Owner.Equals(entrySOH.Owner)
                                 && o.Location.Equals(entrySOH.Location)
                                 && o.ProductCode.Equals(entrySOH.ProductCode)
                                 && o.Colour.Equals(entrySOH.Colour)
                                 && o.Size.Equals(entrySOH.Size)
                                 && o.ArrivalDate.Equals(entrySOH.ArrivalDate));


                    if (entrySOH.Location != newTrans.Location) //location changed
                    {
                        DataBaseSOH toLoc = db.DataBaseSOHs.SingleOrDefault(o =>
                                 o.Branch.Equals(entrySOH.Branch)
                                 && o.Owner.Equals(entrySOH.Owner)
                                 && o.Location.Equals(newTrans.Location)
                                 && o.ProductCode.Equals(entrySOH.ProductCode)
                                 && o.Colour.Equals(entrySOH.Colour)
                                 && o.Size.Equals(entrySOH.Size)
                                 && o.ArrivalDate.Equals(entrySOH.ArrivalDate));

                        if (toLoc == null)
                        {
                            //dbSOH.Location = newTrans.Location;             //newTrans stores updated location
                            DataBaseSOH newSOH = new DataBaseSOH()         //entrySOH stores the previous
                            {
                                ArrivalDate = dbSOH.ArrivalDate,
                                Attribute1 = dbSOH.Attribute1,
                                Attribute2 = dbSOH.Attribute2,
                                Attribute3 = dbSOH.Attribute3,
                                Attribute4 = dbSOH.Attribute4,
                                Attribute5 = dbSOH.Attribute5,
                                BatchNumber = dbSOH.BatchNumber,
                                Branch = dbSOH.Branch,
                                Colour = dbSOH.Colour,
                                ExpiryDate = dbSOH.ExpiryDate,
                                Location = newTrans.Location,   //location changed
                                Owner = dbSOH.Owner,
                                ProductCode = dbSOH.ProductCode,
                                QTY = dbSOH.QTY,
                                RecordIdentifier = dbSOH.RecordIdentifier,
                                SerialNumber = dbSOH.SerialNumber,
                                Size = dbSOH.Size,
                                StockStatus = dbSOH.StockStatus,
                                UOM = dbSOH.UOM
                            };
                            db.DataBaseSOHs.InsertOnSubmit(newSOH);
                        }
                        else
                        {
                            toLoc.QTY += dbSOH.QTY;                            
                        }
                        db.DataBaseSOHs.DeleteOnSubmit(dbSOH);
                    }
                    else
                    {
                        if (dbSOH.QTY != entrySOH.QTY)  //QTY adjust
                        {
                            dbSOH.QTY = entrySOH.QTY;
                        }
                        else if (dbSOH.StockStatus != entrySOH.StockStatus) //stock adjust
                            dbSOH.StockStatus = entrySOH.StockStatus;
                        else
                        {
                            dbSOH.Attribute1 = entrySOH.Attribute1;
                            dbSOH.Attribute2 = entrySOH.Attribute2;
                            dbSOH.Attribute3 = entrySOH.Attribute3;
                            dbSOH.Attribute4 = entrySOH.Attribute4;
                            dbSOH.Attribute5 = entrySOH.Attribute5;
                        }
                    }
                    //db.SubmitChanges();
                    DataBaseTranHistory.addNewTransHistoryEntry(newTrans, db);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
        }

    }

    [Table(Name = "dbo.TranHistory")]
    public class DataBaseTranHistory
    {
        [Column(CanBeNull = false)]
        public string RecordIdentifier { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string Type { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public DateTime Date { get; set; }

        [Column(IsPrimaryKey = true, DbType = "Time(7) NOT NULL", CanBeNull = false)]
        public TimeSpan Time { get; set; }

        [Column(CanBeNull = false)]
        public string User { get; set; }

        [Column(CanBeNull = false)]
        public string Owner { get; set; }

        [Column(CanBeNull = false)]
        public string ProductCode { get; set; }

        [Column(CanBeNull = true)]
        public string Colour { get; set; }

        [Column(CanBeNull = true)]
        public string Size { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string Location { get; set; }

        [Column(CanBeNull = false)]
        public string UOM { get; set; }

        [Column(CanBeNull = false)]
        public float QTY { get; set; }

        [Column(CanBeNull = false)]
        public string JobNumber { get; set; }

        [Column(CanBeNull = false)]
        public DateTime ArrivalDate { get; set; }

        [Column(CanBeNull = true)]
        public string BatchNumber { get; set; }

        [Column(CanBeNull = true)]
        public DateTime ExpiryDate { get; set; }

        [Column(CanBeNull = true)]
        public string SerialNumber { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute1 { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute2 { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute3 { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute4 { get; set; }

        [Column(CanBeNull = true)]
        public string Attribute5 { get; set; }

        [Column(IsPrimaryKey = true, CanBeNull = false)]
        public string StockStatus { get; set; }

        [Column(CanBeNull = false)]
        public int ReasonCode { get; set; }

        [Column(CanBeNull = false)]
        public string Notes { get; set; }

        public string Arrival_Date
        {
            get
            {
                return ArrivalDate.ToString("yyyy-MM-dd");
            }
        }

        public string Expiry_Date
        {
            get
            {
                return ExpiryDate.ToString("yyyy-MM-dd");
            }
        }
        public string date
        {
            get
            {
                return Date.ToString("yyyy-MM-dd");
            }
        }
        public string time
        {
            get
            {
                return Time.ToString("hh:mm:ss");
            }
        }

        public static void addNewTransHistoryEntry(DataBaseTranHistory entryTrans, WMS_Project_DB db)
        {
            entryTrans.User = entryTrans.User.ToLower();
            try
            {
                Table<DataBaseTranHistory> dbTrans = db.DataBaseTrans;
                dbTrans.InsertOnSubmit(entryTrans);
                db.SubmitChanges();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }        
        }
    }
    #endregion DataBaseDefinition


    public class WMS_Project_DB : DataContext
    {
        public Table<DataBaseUser> DataBaseUsers;
        public Table<DataBaseSOH> DataBaseSOHs;
        public Table<DataBaseTranHistory> DataBaseTrans;

        public WMS_Project_DB(string connectionInfo)
            : base(connectionInfo)
        {
        }
    }
}
