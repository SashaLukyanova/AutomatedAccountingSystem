using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using AutomatedAccountingSystem.BusinessObjects;

namespace AutomatedAccountingSystem.Helpers
{
    class DBHelper
    {
        private static string GetConnectionString
        {
            get
            {
                return ConfigurationManager.AppSettings["ConnectionString"];
            }
        }

        public static SqlConnection OpenConnectToDataBase()
        {
            string connectionString = DBHelper.GetConnectionString;
            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();
                //MessageBox.Show("Connection Open ! ");
                return sqlConnection;
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Нет соединения с базой данных, обратитесь к администратору", @"Ошибка соединения", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Environment.Exit(0);
                return null;
            }
        }

        #region Заказчики
        public static void FillCustomersWithActualData(DataSet customersDataSet)
        {
            customersDataSet.Tables["[WorkDB].[dbo].[Customers]"].Clear();

            using (SqlConnection sqlConnection = OpenConnectToDataBase())
            {
                string selectCommand = "SELECT * FROM [WorkDB].[dbo].[Customers]";

                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(selectCommand, sqlConnection);

                adapter.Fill(customersDataSet, "[WorkDB].[dbo].[Customers]");
            }
        }
        

        public static void AddNewCustomer(Customer customer)
        {
            using (SqlConnection sqlConnection = OpenConnectToDataBase())
            {
                string insertCustomerCommand = "INSERT INTO [WorkDB].[dbo].[Customers] ([CustomerName] ,[Phone], [Address]) " +
                    "VALUES ( '" + customer.CustomerName + "', '" + customer.Phone + "', '" + customer.Address + "')";

                SqlCommand insertCommand = new SqlCommand(insertCustomerCommand, sqlConnection);
                insertCommand.ExecuteNonQuery();
            }
            
        }              

        public static void DeleteCustomer(int customerId)
        {
            using (var sqlConnection = DBHelper.OpenConnectToDataBase())
            {
                var deleteCustomerCommand = "DELETE FROM [WorkDB].[dbo].[Customers] WHERE CustomerId = " + customerId;

                var deleteCommand = new SqlCommand(deleteCustomerCommand, sqlConnection);
                deleteCommand.ExecuteNonQuery();

                deleteCommand = new SqlCommand(deleteCustomerCommand, sqlConnection);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public static string GetCustomerNameById(int customerId)
        {
            var customer = new Customer();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                var selectCustomerCommand = "SELECT CustomerName FROM [WorkDB].[dbo].[Customers] WHERE CustomerId = " + customerId;

                var selectCommand = new SqlCommand(selectCustomerCommand, sqlConnection);

                using (var dr = selectCommand.ExecuteReader(CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        customer.CustomerName = dr["CustomerName"].ToString();
                    }
                }
            }

            return customer.CustomerName;
        }

        public static Customer GetCustomerInfoById(int customerId)
        {
            var customer = new Customer();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                var selectCustomerCommand = "SELECT * FROM [WorkDB].[dbo].[Customers] WHERE CustomerId = " + customerId;

                var selectCommand = new SqlCommand(selectCustomerCommand, sqlConnection);

                using (var dr = selectCommand.ExecuteReader(CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        customer.CustomerId = (int)dr["CustomerId"];
                        customer.CustomerName = dr["CustomerName"].ToString();
                        customer.Phone = dr["Phone"].ToString();
                        customer.Address = dr["Address"].ToString();
                    }
                }
            }

            return customer;
        }

        public static void UpdateDBCustomers(int customerId, Customer editedCustomer)
        {
            if(ParseHelper.CustomerValidate(editedCustomer))
                return;
            using (var sqlConnection = OpenConnectToDataBase())
            {
                string updateCustomerCommand = "UPDATE [WorkDB].[dbo].[Customers] SET " +
                        "[CustomerName] = '" + editedCustomer.CustomerName +
                        "', [Phone] = '" + editedCustomer.Phone +
                        "', [Address] = '" + editedCustomer.Address +
                        "' WHERE CustomerId=" + customerId;

                var updateCommand = new SqlCommand(updateCustomerCommand, sqlConnection);
                updateCommand.ExecuteNonQuery();
            }
        }

        
        #endregion

        #region КРС
        public static void FillCattlesWithActualData(DataSet cattlesDataSet)
        {
            cattlesDataSet.Tables["[WorkDB].[dbo].[Cattles]"].Clear();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                string selectCommand = "SELECT * FROM [WorkDB].[dbo].[Cattles]";

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(selectCommand, sqlConnection);

                adapter.Fill(cattlesDataSet, "[WorkDB].[dbo].[Cattles]");
            }
        }

        public static void AddNewCattle(Cattle cattle)
        {
            using (SqlConnection sqlConnection = OpenConnectToDataBase())
            {
                string insertCattleCommand = "INSERT INTO [WorkDB].[dbo].[Cattles] ([ObjectsGroup] ,[LiveWeight], [Age], [Fatness], [InventoryNum], [Number], [Price]) " +
                    "VALUES ( '" + cattle.ObjectsGroup + "', " + ParseHelper.ReplacementPoint(cattle.LiveWeight) + ", " + ParseHelper.ReplacementPoint(cattle.Age) +
                    ", '" + cattle.Fatness + "', " + ParseHelper.ReplacementPoint(cattle.InventoryNum) + ", " + cattle.Number + ", " + ParseHelper.ReplacementPoint(cattle.Price) + ")";

                SqlCommand insertCommand = new SqlCommand(insertCattleCommand, sqlConnection);
                insertCommand.ExecuteNonQuery();
            }            
        }

        public static void DeleteCattle(int cattleId)
        {
            using (var sqlConnection = DBHelper.OpenConnectToDataBase())
            {
                var deleteCattleCommand = "DELETE FROM [WorkDB].[dbo].[Cattles] WHERE CattleId = " + cattleId;

                var deleteCommand = new SqlCommand(deleteCattleCommand, sqlConnection);
                deleteCommand.ExecuteNonQuery();

                deleteCommand = new SqlCommand(deleteCattleCommand, sqlConnection);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public static string GetCattleNameById(int cattleId)
        {
            var cattle = new Cattle();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                var selectCattleCommand = "SELECT ObjectsGroup FROM [WorkDB].[dbo].[Cattles] WHERE CattleId = " + cattleId;

                var selectCommand = new SqlCommand(selectCattleCommand, sqlConnection);

                using (var dr = selectCommand.ExecuteReader(CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        cattle.ObjectsGroup = dr["ObjectsGroup"].ToString();
                    }
                }
            }

            return cattle.ObjectsGroup;
        }

        public static Cattle GetCattleInfoById(int cattleId)
        {
            var cattle = new Cattle();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                var selectCattleCommand = "SELECT * FROM [WorkDB].[dbo].[Cattles] WHERE CattleId = " + cattleId;

                var selectCommand = new SqlCommand(selectCattleCommand, sqlConnection);

                using (var dr = selectCommand.ExecuteReader(CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        cattle.CattleId = (int)dr["CattleId"];
                        cattle.ObjectsGroup = dr["ObjectsGroup"].ToString();
                        cattle.Age = Convert.ToSingle(dr["Age"].ToString());
                        cattle.Fatness = dr["Fatness"].ToString();
                        cattle.LiveWeight = Convert.ToSingle(dr["LiveWeight"].ToString());
                        cattle.InventoryNum = Convert.ToSingle(dr["InventoryNum"].ToString());
                        cattle.Number = Convert.ToInt32(dr["Number"].ToString());
                        cattle.Price = Convert.ToSingle(dr["Price"].ToString());
                    }
                }
            }

            return cattle;
        }

        public static void UpdateDBCattles(int cattleId, Cattle editedCattle)
        {
            using (var sqlConnection = OpenConnectToDataBase())
            {
                string updateCattleCommand = "UPDATE [WorkDB].[dbo].[Cattles] SET " +
                        "[ObjectsGroup] = '" + editedCattle.ObjectsGroup +
                        "', [LiveWeight] = " + ParseHelper.ReplacementPoint(editedCattle.LiveWeight) +
                        ", [Age] = " + ParseHelper.ReplacementPoint(editedCattle.Age) +
                        ", [Fatness] = '" + editedCattle.Fatness +
                        "', [InventoryNum] = " + ParseHelper.ReplacementPoint(editedCattle.InventoryNum) +
                        ", [Number] = " + editedCattle.Number +
                        ", [Price] = " + ParseHelper.ReplacementPoint(editedCattle.Price) +
                        " WHERE CattleId=" + cattleId;

                var updateCommand = new SqlCommand(updateCattleCommand, sqlConnection);
                updateCommand.ExecuteNonQuery();
            }
        }
        #endregion

        #region Заказы
        public static void FillOrdersWithActualData(DataSet ordersDataSet)
        {
            ordersDataSet.Tables["[WorkDB].[dbo].[Orders]"].Clear();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                string selectCommand = "SELECT * FROM [WorkDB].[dbo].[Orders]";

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(selectCommand, sqlConnection);

                adapter.Fill(ordersDataSet, "[WorkDB].[dbo].[Orders]");
            }
        }

        public static void AddNewOrder(Order order)
        {
            using (SqlConnection sqlConnection = OpenConnectToDataBase())
            {
                string insertOrderCommand = "INSERT INTO [WorkDB].[dbo].[Orders] ([TransportOwner] ,[Auto], [Waybill], [Driver], [TypeTransporation]," +
                    " [Shipper], [Consignee], [LoadingPoint], [ShippingPoint], [Route], [Contract], [Trailer], [Garage], [Rate], " +
                    "[DateContract], [DateShipping], [Customer], [Product]" +
                    " ) VALUES ( '" + order.TransportOwner + "', '" + order.Auto + "', '" + order.Waybill + "', '" + order.Driver + "', '" + 
                    order.TypeTransporation + "', '"  + order.Shipper + "', '" + order.Consignee +
                    "', '" + order.LoadingPoint + "', '" + order.ShippingPoint + "', '" + order.Route + "', '" + order.Contract + "', '" + order.Trailer + "', '"
                    + order.Garage + "', " + ParseHelper.ReplacementPoint(order.Rate) + ", '" + ParseHelper.CorrectDateTime(order.DateContract) + "', '"
                    + ParseHelper.CorrectDateTime(order.DateShipping) + "', " + order.Customer + "," + order.Product +")";

                SqlCommand insertCommand = new SqlCommand(insertOrderCommand, sqlConnection);
                insertCommand.ExecuteNonQuery();
            }
                        
        }        
        
        public static void AddNewOrderMilk(OrderMilk order)
        {
            using (SqlConnection sqlConnection = OpenConnectToDataBase())
            {
                string insertOrderMilkCommand = "INSERT INTO [WorkDB].[dbo].[OrderMilk] ([OrderId] ,[MilkId]" +
                    " ) VALUES ( " + order.OrderId + ", " + order.MilkId + ")";

                SqlCommand insertCommand = new SqlCommand(insertOrderMilkCommand, sqlConnection);
                insertCommand.ExecuteNonQuery();
            }

        }

        public static void AddNewOrderCattle(OrderCattle order)
        {
            using (SqlConnection sqlConnection = OpenConnectToDataBase())
            {
                string insertOrderCattleCommand = "INSERT INTO [WorkDB].[dbo].[OrderCattle] ([OrderId] ,[CattleId]" +
                    " ) VALUES ( " + order.OrderId + ", " + order.CattleId + ")";

                SqlCommand insertCommand = new SqlCommand(insertOrderCattleCommand, sqlConnection);
                insertCommand.ExecuteNonQuery();
            }

        }

        public static void DeleteOrder(int orderId)
        {
            using (var sqlConnection = DBHelper.OpenConnectToDataBase())
            {
                var deleteOrderCommand = "DELETE FROM [WorkDB].[dbo].[Orders] WHERE OrderId = " + orderId;

                var deleteCommand = new SqlCommand(deleteOrderCommand, sqlConnection);
                deleteCommand.ExecuteNonQuery();

                deleteCommand = new SqlCommand(deleteOrderCommand, sqlConnection);
                deleteCommand.ExecuteNonQuery();
            }
        }
        
        public static Order GetOrderInfoById(int orderId)
        {
            var order = new Order();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                var selectOrderCommand = "SELECT * FROM [WorkDB].[dbo].[Orders] WHERE OrderId = " + orderId;

                var selectCommand = new SqlCommand(selectOrderCommand, sqlConnection);

                using (var dr = selectCommand.ExecuteReader(CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        order.OrderId = (int)dr["OrderId"];
                        order.TransportOwner = dr["TransportOwner"].ToString();
                        order.Auto = dr["Auto"].ToString();
                        order.Waybill = dr["Waybill"].ToString();
                        order.Driver = dr["Driver"].ToString();
                        order.TypeTransporation = dr["TypeTransporation"].ToString();                        
                        order.Shipper = dr["Shipper"].ToString();
                        order.Consignee = dr["Consignee"].ToString();
                        order.LoadingPoint = dr["LoadingPoint"].ToString();
                        order.ShippingPoint = dr["ShippingPoint"].ToString();
                        order.Route = dr["Route"].ToString();
                        order.Contract = dr["Contract"].ToString();
                        order.Trailer = dr["Trailer"].ToString();
                        order.Garage = dr["Garage"].ToString();
                        order.Rate = Convert.ToSingle(dr["Rate"].ToString());
                        order.DateContract = (DateTime)dr["DateContract"];
                        order.DateShipping = (DateTime)dr["DateShipping"];
                        order.Customer = ParseHelper.ParseToInt(dr["Customer"].ToString());
                        order.Product = ParseHelper.ParseToInt(dr["Product"].ToString());
                    }
                }
            }

            return order;
        }

        public static void UpdateDBOrders(int orderId, Order editedOrder)
        {
            using (var sqlConnection = OpenConnectToDataBase())
            {
                string updateOrderCommand = "UPDATE [WorkDB].[dbo].[Orders] SET " +
                        "[TransportOwner] = '" + editedOrder.TransportOwner +
                        "', [Auto] = '" + editedOrder.Auto +
                        "', [Waybill] = '" + editedOrder.Waybill +
                        "', [Driver] = '" + editedOrder.Driver +
                        "', [TypeTransporation] = '" + editedOrder.TypeTransporation +
                        "', [Shipper] = '" + editedOrder.Shipper +
                        "', [Consignee] = '" + editedOrder.Consignee +
                        "', [LoadingPoint] = '" + editedOrder.LoadingPoint +
                        "', [ShippingPoint] = '" + editedOrder.ShippingPoint +
                        "', [Route] = '" + editedOrder.Route +
                        "', [Contract] = '" + editedOrder.Contract +
                        "', [Trailer] = '" + editedOrder.Trailer +
                        "', [Garage] = '" + editedOrder.Garage +
                        "', [Rate] = " + ParseHelper.ReplacementPoint(editedOrder.Rate) +
                        ", [DateContract] = '" + ParseHelper.CorrectDateTime(editedOrder.DateContract) +
                        "', [DateShipping] = '" + ParseHelper.CorrectDateTime(editedOrder.DateShipping) +
                        //"', [Customer] = " + ParseHelper.ParseToInt(editedOrder.Customer.ToString()) +
                        //", [Product] = " + ParseHelper.ParseToInt(editedOrder.Product.ToString()) +
                        "' WHERE OrderId=" + orderId;

                var updateCommand = new SqlCommand(updateOrderCommand, sqlConnection);
                updateCommand.ExecuteNonQuery();
            }
        }
        #endregion

        #region Молоко
        public static void FillMilkWithActualData(DataSet milkDataSet)
        {
            milkDataSet.Tables["[WorkDB].[dbo].[Milk]"].Clear();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                string selectCommand = "SELECT * FROM [WorkDB].[dbo].[Milk]";

                var adapter = new SqlDataAdapter();
                adapter.SelectCommand = new SqlCommand(selectCommand, sqlConnection);

                adapter.Fill(milkDataSet, "[WorkDB].[dbo].[Milk]");
            }
        }

        public static void AddNewMilk(Milk milk)
        {            
            using (SqlConnection sqlConnection = OpenConnectToDataBase())
            {
                string insertMilkCommand = "INSERT INTO [WorkDB].[dbo].[Milk] ([Class] ,[Density], [FatContent], [Acidity], [Temperature], " +
                    "[Packing], [Seats], [Grossmass], [NetMass], [TareMass], [Bucterial], [BaseMass], [GroupPurity], [Price])"+
                "VALUES ( '" + milk.Class + "', '" + milk.Density + "', " + ParseHelper.ReplacementPoint(milk.FatContent) + ", " + ParseHelper.ReplacementPoint(milk.Acidity) + 
                ", " + ParseHelper.ReplacementPoint(milk.Temperature) + ", '" + milk.Packing +"', " + milk.Seats + ", " + ParseHelper.ReplacementPoint(milk.Grossmass) + ", " + 
                ParseHelper.ReplacementPoint(milk.NetMass) + ", " + ParseHelper.ReplacementPoint(milk.TareMass) + ", '" + milk.Bucterial + "', " + 
                ParseHelper.ReplacementPoint(milk.BaseMass) + ", '" + milk.GroupPurity + "', " + ParseHelper.ReplacementPoint(milk.Price) + ")";
                SqlCommand insertCommand = new SqlCommand(insertMilkCommand, sqlConnection);
                insertCommand.ExecuteNonQuery();
            }
        }

        public static void DeleteMilk(int milkId)
        {
            using (var sqlConnection = DBHelper.OpenConnectToDataBase())
            {
                var deleteMilkCommand = "DELETE FROM [WorkDB].[dbo].[Milk] WHERE MilkId = " + milkId;

                var deleteCommand = new SqlCommand(deleteMilkCommand, sqlConnection);
                deleteCommand.ExecuteNonQuery();

                deleteCommand = new SqlCommand(deleteMilkCommand, sqlConnection);
                deleteCommand.ExecuteNonQuery();
            }
        }

        public static string GetMilkNameById(int milkId)
        {
            var milk = new Milk();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                var selectMilkCommand = "SELECT Class FROM [WorkDB].[dbo].[Milk] WHERE MilkId = " + milkId;

                var selectCommand = new SqlCommand(selectMilkCommand, sqlConnection);

                using (var dr = selectCommand.ExecuteReader(CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        milk.Class = dr["Class"].ToString();                        
                    }
                }
            }

            return milk.Class;
        }

        public static Milk GetMilkInfoById(int milkId)
        {
            var milk = new Milk();

            using (var sqlConnection = OpenConnectToDataBase())
            {
                var selectMilkCommand = "SELECT * FROM [WorkDB].[dbo].[Milk] WHERE MilkId = " + milkId;

                var selectCommand = new SqlCommand(selectMilkCommand, sqlConnection);

                using (var dr = selectCommand.ExecuteReader(CommandBehavior.Default))
                {
                    if (dr.Read())
                    {
                        milk.MilkId = (int)dr["MilkId"];
                        milk.Acidity = Convert.ToSingle(dr["Acidity"].ToString());
                        milk.BaseMass = Convert.ToSingle(dr["BaseMass"].ToString());
                        milk.Bucterial = dr["Bucterial"].ToString();
                        milk.Class = dr["Class"].ToString();
                        milk.Density = dr["Density"].ToString();
                        milk.FatContent = Convert.ToSingle(dr["FatContent"].ToString());
                        milk.Grossmass = Convert.ToSingle(dr["Grossmass"].ToString());
                        milk.GroupPurity = dr["GroupPurity"].ToString();
                        milk.NetMass = Convert.ToSingle(dr["NetMass"].ToString());
                        milk.Packing = dr["Packing"].ToString();
                        milk.Price = Convert.ToSingle(dr["Price"].ToString());
                        milk.Seats = (int)dr["Seats"];
                        milk.TareMass = Convert.ToSingle(dr["TareMass"].ToString());
                        milk.Temperature = Convert.ToSingle(dr["Temperature"].ToString());
                    }
                }
            }

            return milk;
        }

        public static void UpdateDBMilk(int milkId, Milk editedMilk)
        {
            using (var sqlConnection = OpenConnectToDataBase())
            {
                string updateMilkCommand = "UPDATE [WorkDB].[dbo].[Milk] SET " +
                        "[Class] = '" + editedMilk.Class +
                        "', [Density] = '" + editedMilk.Density +
                        "', [FatContent] = " + ParseHelper.ReplacementPoint(editedMilk.FatContent) +
                        ", [Acidity] = " + ParseHelper.ReplacementPoint(editedMilk.Acidity) +
                        ", [Temperature] = " + ParseHelper.ReplacementPoint(editedMilk.Temperature) +
                        ", [Packing] = '" + editedMilk.Packing +
                        "', [Seats] = " + editedMilk.Seats +
                        ", [Grossmass] = " + ParseHelper.ReplacementPoint(editedMilk.Grossmass) +
                        ", [NetMass] = " + ParseHelper.ReplacementPoint(editedMilk.NetMass) +
                        ", [TareMass] = " + ParseHelper.ReplacementPoint(editedMilk.TareMass) +
                        ", [Bucterial] = '" + editedMilk.Bucterial +
                        "', [BaseMass] = " + ParseHelper.ReplacementPoint(editedMilk.BaseMass) +
                        ", [Price] = " + ParseHelper.ReplacementPoint(editedMilk.Price) +
                        " WHERE MilkId=" + milkId;

                var updateCommand = new SqlCommand(updateMilkCommand, sqlConnection);
                updateCommand.ExecuteNonQuery();
            }
        }
        #endregion

       
    }
}

