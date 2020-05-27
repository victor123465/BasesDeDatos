using System;
using System.Linq;
using static System.Console;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;
using System.Diagnostics;



namespace BasesDeDatos
{
    class Program
    {
        static void Main(string[] args)
        {
            //Este ejercicio sirve para editar bases de datos añadir datos a tablas.
            var CadenaDeConexion=new SqliteConnectionStringBuilder();
            CadenaDeConexion.DataSource=@"C:\SQLite\Northwind.db";
            using (var conexion=new SqliteConnection(CadenaDeConexion.ConnectionString))
            {
                conexion.Open();
                var CreateTableCMD=conexion.CreateCommand();

                /*
                CreateTableCMD.CommandText="ALTER TABLE PagingTest ADD FechaYHora datetime";
                CreateTableCMD.ExecuteNonQuery();
                WriteLine("campo añadido. Compruébalo");
                */

                //borro el contenido de toda la tabla
                CreateTableCMD.CommandText="DELETE FROM PagingTest";
                CreateTableCMD.ExecuteNonQuery();
                WriteLine("Limpiando tabla");

                //Método Lento.
                /*var Temporizador=Stopwatch.StartNew();
                using(var db=new NorthwindContext())
                {
                    for(int i=1;i<=1000;i++)
                     {
                         var Prueba=new PagingTest();
                         Prueba.Id=i;
                         Prueba.Row=i*2;
                         Prueba.FechaYHora=DateTime.Now;
                         db.PagingTest.Add(Prueba);
                         db.SaveChanges();
                         if(i%100==0)
                         {
                             WriteLine($"Alcanzados los {i}");
                         }
                     }
                }
                WriteLine($"Temporizador terminado en {Temporizador.ElapsedMilliseconds} ms");
                */
                //Método rápido
                var Temporizador=Stopwatch.StartNew();
                using(var db=new NorthwindContext())
                {
                    for(int i=1;i<=1000;i++)
                     {
                         var Prueba=new PagingTest();
                         Prueba.Id=i;
                         Prueba.Row=i*2;
                         Prueba.FechaYHora=DateTime.Now;
                         db.PagingTest.Add(Prueba);
                         
                         if(i%100==0)
                         {
                             db.SaveChanges();
                             WriteLine($"Alcanzados los {i}");
                         }
                     }
                }
                WriteLine($"Temporizador terminado en {Temporizador.ElapsedMilliseconds} ms");
            }


            //Ejercicio1();
            //Ejercicio2();
            //Ejercicio3();
            //Ejercicio4();
            //Ejercicio5();

            //Ejercicio6();
            //Ejercicio7();
            //Ejercicio8();
            //Ejercicio9();
            //Ejercicio10();

            //Ejercicio11();
            //Ejercicio12();
            //Ejercicio13();
            //Ejercicio14();
            //Ejercicio15();

            //Ejercicio16();
            //Ejercicio17();
            //Ejercicio18();
            //Ejercicio19();
            //Ejercicio20();

            //Ejercicio21();
            //Ejercicio22();
            //Ejercicio23();
            //Ejercicio24();
            //Ejercicio25();

            //Ejercicio26();
            //Ejercicio27();
            //Ejercicio28();
            //Ejercicio29();
            //Ejercicio30();

            //Ejercicio31();
            //Ejercicio32();
            //Ejercicio33();
            //Ejercicio34();
            //Ejercicio35();
            //Ejercicio36();
        }
        static void Ejercicio1()
        {
            //Clientes de USA
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Clientes en USA");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var ClientesUsa=db.Customers
                .Where(x=>x.Country=="USA");
                WriteLine("CustomerID\tContactName\t\tCountry");
                foreach (var item in ClientesUsa)
                {
                    WriteLine($"{item.CustomerId}\t\t{item.ContactName}\t\t{item.Country}");
                }
            }
            WriteLine();
        }
        static void Ejercicio2()
        {
            //Proveedores de Berlín
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Proveedores de Berlín");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Proveedores=db.Suppliers
                .Where(x=>x.City=="BERLIN");
                WriteLine("SupplierID\tContactName\tCountry");
                foreach (var item in Proveedores)
                {
                    WriteLine($"{item.SupplierId}\t\t{item.ContactName}\t{item.Country}");
                }
            }
            WriteLine();
        }
        static void Ejercicio3()
        {
            //Empleados código 3,5 y 8
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Empleados código 3,5 y 8");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Empleados=db.Employees
                .Where(x=>x.EmployeeId==3 || x.EmployeeId==5 || x.EmployeeId==8);
                WriteLine("EmployeeID\tFirstName\tLastName");
                foreach (var item in Empleados)
                {
                    WriteLine($"{item.EmployeeId}\t\t{item.FirstName}\t\t{item.LastName}");
                }
            }
            WriteLine();
        }
        static void Ejercicio4()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Productos estock>0 y proveedores 1,3 y 5");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Products
                .Where(x=>x.UnitsInStock>0 && (x.SupplierId==1 || x.SupplierId==3 || x.SupplierId==5));
                WriteLine("Product ID\tStock\tSupplierID");
                foreach (var item in Productos)
                {
                    WriteLine($"{item.ProductId}\t\t{item.UnitsInStock}\t\t{item.SupplierId}");
                }
            }
            WriteLine();
        }
        static void Ejercicio5()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Productos precio>=20 y precio<=90");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Products
                .Where(x=>x.UnitPrice>=20.0 && x.UnitPrice<=90 )
                .OrderBy(x=>x.UnitPrice);
                WriteLine("Product ID\tStock\tUnitPrice");
                foreach (var item in Productos)
                {
                    WriteLine($"{item.ProductId}\t\t{item.UnitsInStock}\t{item.UnitPrice}");
                }
            }
            WriteLine();
        }
        static void Ejercicio6()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Ordenes de compra entre 1/1/1997 y 15/07/1997");
            ForegroundColor=ConsoleColor.White;
            DateTime inicio=new DateTime(1997,1,1);
            DateTime final=new DateTime(1997,7,15);
            using(var db=new NorthwindContext())
            {
                var Productos=db.Orders
                .Where(x=>x.OrderDate>=inicio && x.OrderDate<=final );
                WriteLine("Order ID\tFecha");
                foreach (var item in Productos)
                {
                    WriteLine($"{item.OrderId}\t\t{item.OrderDate.Value.ToString("dd/MM/yyy")}");
                }
            }
            WriteLine();
        }
        static void Ejercicio7()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Compras hechas en 1997 de empleados 1,3,4,8");
            ForegroundColor=ConsoleColor.White;
            long[] codigos={1,3,4,8};
            using(var db=new NorthwindContext())
            {
                var Productos=db.Orders
                .Where(x=>x.OrderDate.Value.Year==1997 && codigos.Contains(x.EmployeeId.Value));
                WriteLine("Order ID\tFecha\t\tEmployeedID");
                foreach (var item in Productos)
                {
                    WriteLine($"{item.OrderId}\t\t{item.OrderDate.Value.ToString("dd/MM/yyy")}\t{item.EmployeeId}");
                }
            }
            WriteLine();
        }
        static void Ejercicio8()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Ordenes hechas en el año 1996");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Orders
                .Where(x=>x.OrderDate.Value.Year==1996);
                WriteLine("Order ID\tFecha\t\tEmployeedID");
                foreach (var item in Productos)
                {
                    WriteLine($"{item.OrderId}\t\t{item.OrderDate.Value.ToString("dd/MM/yyy")}\t{item.EmployeeId}");
                }
            }
            WriteLine();
        }
        static void Ejercicio9()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Ordenes hechas en el año 1997 y mes Abril");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Orders
                .Where(x=>x.OrderDate.Value.Year==1997 && x.OrderDate.Value.Month==4);
                WriteLine("Order ID\tFecha\t\tEmployeedID");
                foreach (var item in Productos)
                {
                    WriteLine($"{item.OrderId}\t\t{item.OrderDate.Value.ToString("dd/MM/yyy")}\t{item.EmployeeId}");
                }
            }
            WriteLine();
        }
        static void Ejercicio10()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Ordenes hechas el 1 de todos los meses de 1998");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Orders
                .Where(x=>x.OrderDate.Value.Year==1998 && x.OrderDate.Value.Day==1);
                WriteLine("Order ID\tFecha\t\tEmployeedID");
                foreach (var item in Productos)
                {
                    WriteLine($"{item.OrderId}\t\t{item.OrderDate.Value.ToString("dd/MM/yyy")}\t{item.EmployeeId}");
                }
            }
            WriteLine();
        }
        static void Ejercicio11()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Clientes que tienen fax");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Customers
                .Where(x=>!string.IsNullOrEmpty(x.Fax));
                WriteLine("CustomerID\tFax");
                foreach (var item in Productos)
                {
                    WriteLine($"{item.CustomerId}\t\t{item.Fax}");
                }
            }
            WriteLine();
        }
        static void Ejercicio12()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Clientes que no tienen fax");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Customers
                .Where(x=>string.IsNullOrEmpty(x.Fax));
                WriteLine("CustomerID\tContactName");
                foreach (var item in Productos)
                {
                    WriteLine($"{item.CustomerId}\t\t{item.ContactName}");
                }
            }
            WriteLine();
        }
        static void Ejercicio13()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Nombre del Producto, Stock,Nombre Categoria a la que pertenecen");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Products
                .Include(x=>x.Category);
                WriteLine("Producto{0,-27}Precio{1,-5}Stock{2,-5}Categoría",null,null,null);
                foreach (var item in Productos)
                {
                    WriteLine("{0,-35}{1,-12}{2,-10}{3}",item.ProductName,item.UnitPrice,item.UnitsInStock,item.Category.CategoryName);
                }
            }
            WriteLine();
        }
        static void Ejercicio14()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Nombre del Producto,Código del proveedor,Nombre de la compañía");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Products
                .Include(x=>x.Supplier);
                WriteLine("Producto{0,-25}Precio{1,-5}ProveedorID{2,-5}Compañía",null,null,null);
                foreach (var item in Productos)
                {
                    WriteLine("{0,-35}{1,-10}{2,-10}{3}",item.ProductName,item.UnitPrice,item.SupplierId,item.Supplier.CompanyName);
                }
            }
            WriteLine();
        }
        static void Ejercicio15()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Numero de orden, código del producto,precio,cantidad,coste total");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.OrderDetails;
                WriteLine("OrdereID\tProductID\tUnitPrice\tQuantity\tTotal");
                foreach (var item in Productos)
                {
                    double total=item.Quantity*item.UnitPrice*(1-item.Discount);
                    WriteLine($"{item.OrderId}\t\t{item.ProductId}\t\t{item.UnitPrice}\t\t{item.Quantity}\t\t{total:N2}");
                }
            }
            WriteLine();
        }
        static void Ejercicio16()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Numero de orden, código del producto,precio,código del empleado,nombre completo");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Ordenes=db.OrderDetails
                .Include(x=>x.Order)
                .Join(
                    db.Employees,
                    x=>x.Order.EmployeeId,
                    y=>y.EmployeeId,
                    (x,y)=>new{
                        Orders=x,
                        Empleados=y
                    }
                    )
                    .Distinct();
                
                WriteLine("OrdereID\tProductID\tUnitPrice\tEmployeeID\tNombre");
                foreach (var item in Ordenes)
                {
                    
                    WriteLine($"{item.Orders.OrderId}\t\t{item.Orders.ProductId}\t\t{item.Orders.UnitPrice}\t\t{item.Empleados.EmployeeId}\t\t{item.Empleados.FirstName} {item.Empleados.LastName}");
                }
            }
            WriteLine();
        }
        static void Ejercicio17()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Productos con menor stock");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Products
                .OrderBy(x=>x.UnitsInStock)
                .Take(10);
                WriteLine("ProductID\tUnitinStock\tNombreProducto");
                foreach(var d in Productos)
                {
                    WriteLine($"{d.ProductId}\t\t{d.UnitsInStock}\t\t{d.ProductName}");
                }
            }
            WriteLine();
        }
        static void Ejercicio18()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("10 Productos con mayor stock");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Products
                .OrderByDescending(x=>x.UnitsInStock)
                .ToList();
                WriteLine("ProductID\tUnitinStock\tNombreProducto");
                for(int i=0;i<10;i++)
                {
                    var elemento=Productos.ElementAt(i);
                    WriteLine($"{elemento.ProductId}\t\t{elemento.UnitsInStock}\t\t{elemento.ProductName}");
                }
            }
            WriteLine();
        }
        static void Ejercicio19()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("10 Productos con menor precio");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Products
                .OrderBy(x=>x.UnitPrice)
                .ToList();
                WriteLine("ProductID\tUnitPrice\tNombreProducto");
                for(int i=0;i<10;i++)
                {
                    var elemento=Productos.ElementAt(i);
                    WriteLine($"{elemento.ProductId}\t\t{elemento.UnitPrice}\t\t{elemento.ProductName}");
                }
            }
            WriteLine();
        }
        static void Ejercicio20()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("10 Productos con mayor precio");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var Productos=db.Products
                .OrderByDescending(x=>x.UnitPrice)
                .ToList();
                WriteLine("ProductID\tUnitPrice\tNombreProducto");
                for(int i=0;i<10;i++)
                {
                    var elemento=Productos.ElementAt(i);
                    WriteLine($"{elemento.ProductId}\t\t{elemento.UnitPrice}\t\t{elemento.ProductName}");
                }
            }
            WriteLine();
        }
        static void Ejercicio21()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Seleccionar todos los campos de clientes y ordenar por compañía");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var clientes=db.Customers
                .OrderBy(x=>x.CompanyName);
                WriteLine("CustomerID\tCompanyName");
                foreach(var item in clientes)
                {
                    WriteLine($"{item.CustomerId}\t\t{item.CompanyName}");
                }
            }
            WriteLine();
        }
        static void Ejercicio22()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Clientes que empiezan por B y son de UK");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var clientes=db.Customers
                .ToList()
                .Where(x=>x.Country=="UK" && x.CompanyName.StartsWith('B'))
                .OrderBy(x=>x.CompanyName);
                WriteLine("CustomerID\tCompanyName\t\tCountry");
                foreach(var item in clientes)
                {
                    WriteLine($"{item.CustomerId}\t\t{item.CompanyName}\t\t{item.Country}");
                }
            }
            WriteLine();
        }
        static void Ejercicio23()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Seleccionar productos categorías 1,3 y 5");
            ForegroundColor=ConsoleColor.White;
            
            using(var db=new NorthwindContext())
            {
                long[] id={1,3,5};
                var clientes=db.Products
                .Include(x=>x.Category)
                .Where(x=>id.Contains(x.CategoryId.Value))
                .OrderBy(x=>x.CategoryId)
                .ToList()
                .GroupBy(x=>x.Category);

                foreach(var item in clientes)
                {
                    ForegroundColor=ConsoleColor.Cyan;
                    WriteLine($"CategoryID: {item.Key.CategoryId}");
                    ForegroundColor=ConsoleColor.White;
                    foreach(var d in item)
                    {
                        WriteLine($"ProductID: {d.ProductId}\t\tProductName: {d.ProductName}");
                    }
                }
            }
            WriteLine();
        }
          static void Ejercicio24()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Clientes que empiezan por B y son de UK");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var clientes=db.Products
                .Where(x=>x.UnitPrice>=50 && x.UnitPrice<=200)
                .OrderBy(x=>x.UnitPrice);
                WriteLine("ProductID\tProductName\t\tUnitPrice");
                foreach(var item in clientes)
                {
                    WriteLine($"{item.ProductId}\t\t{item.ProductName}\t\t{item.UnitPrice}");
                }
            }
            WriteLine();
        }
        static void Ejercicio25()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Nombre de la compañía, id, fecha,precio unitario y producto de la orden");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var clientes=db.OrderDetails
                .Include(x=>x.Order)
                .Join(
                    db.Customers,
                    x=>x.Order.CustomerId,
                    y=>y.CustomerId,
                    (x,y)=>new{
                        DatosProd=x,
                        DatosCustomer=y
                    }
                );
                WriteLine("CompanyID{0}\t\tCompanyName{1,-15}OrderDate{2}\tUnitPrice{3}\tProductID",null,null,null,null);
                foreach(var item in clientes)
                {
                    WriteLine("{0}\t\t{1,-35}{2}\t{3,-15}\t{4}",item.DatosCustomer.CustomerId,item.DatosCustomer.CompanyName,item.DatosProd.Order.OrderDate.Value.ToString("dd/MM/yyyy"),item.DatosProd.UnitPrice,item.DatosProd.ProductId);
                }
            }
            WriteLine();
        }
        static void Ejercicio26()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Categoría y número de productos que hay en ella");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var categorias=db.Categories
                .Include(x=>x.Products);
                WriteLine("Categoría\tNº Productos");
                foreach(var item in categorias)
                {
                    WriteLine("{0,-20}{1}",item.CategoryName,item.Products.Count);
                }
            }
        }
        static void Ejercicio27()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("5 productos más vendidos");
            ForegroundColor=ConsoleColor.White;
            WriteLine("ProductID\tUnitsInOrder");
            using(var db=new NorthwindContext())
            {
                var productos=db.Products
                .OrderByDescending(x=>x.UnitsOnOrder)
                .Take(5);
                foreach(var item in productos)
                {
                    WriteLine("{0,-20}{1}",item.ProductId,item.UnitsOnOrder);
                }
            }
        }
        static void Ejercicio28()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Productos que empiezan por M y tienen un precio entre 28 y 129");
            ForegroundColor=ConsoleColor.White;
            WriteLine("ProductID\tProductName\t\tUnitPrice");
            using(var db=new NorthwindContext())
            {
                var productos=db.Products
                .Where(x=>x.ProductName.Substring(0,1)=="M" && x.UnitPrice>=28 && x.UnitPrice<=129);
                foreach(var item in productos)
                {
                    WriteLine("{0}\t\t{1,-25}{2}",item.ProductId,item.ProductName,item.UnitPrice);
                }
            }
        }
        static void Ejercicio29()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Clientes de USA, Francia y UK");
            ForegroundColor=ConsoleColor.White;
            WriteLine("CompanyName\t\t\t\tCountry");
            using(var db=new NorthwindContext())
            {
                var clientes=db.Customers
                .Where(x=>x.Country=="USA" || x.Country=="France" || x.Country=="UK");
                foreach(var item in clientes)
                {
                    WriteLine("{0,-35}\t{1}",item.CompanyName,item.Country);
                }
            }
        }
        static void Ejercicio30()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Productos con stock 0 o discontinuas");
            ForegroundColor=ConsoleColor.White;
            WriteLine("ProductID\tProductName\t\t\tUnitStock\tDiscontinuedDate");
            using(var db=new NorthwindContext())
            {
                var productos=db.Products
                .Where(x=>x.Discontinued==1 || x.UnitsInStock==0);
                foreach(var item in productos)
                {
                    if(item.DiscontinuedDate==null)
                    {
                        WriteLine("{0,-15}{1,-35}{2,-15}{3}",item.ProductId,item.ProductName,item.UnitsInStock,"null");
                    }else
                    {
                        WriteLine("{0,-15}{1,-35}{2,-15}{3}",item.ProductId,item.ProductName,item.UnitsInStock,item.DiscontinuedDate.Value.ToString("dd/MM/yyyy"));
                    }
                   
                }
            }
        }
        static void Ejercicio31()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Órdenes del cliente con ID=QUEDE");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var ordenes=db.Orders
                .Where(x=>x.CustomerId=="QUEDE");
                WriteLine("OrderID\tCustomerID");
                foreach(var item in ordenes)
                {
                    WriteLine("{0}\t{1}",item.OrderId,item.CustomerId);
                    
                }
            }
        }
        static void Ejercicio32()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Productos orden 10257");
            ForegroundColor=ConsoleColor.White;
            WriteLine("ProductID\tProductName\t\tUnitPrice\tStock");
            using(var db=new NorthwindContext())
            {
                var productos=db.Products
                .Join(
                    db.OrderDetails,
                    x=>x.ProductId,
                    y=>y.ProductId,
                    (x,y)=>new{
                        datosProd=x,
                        datosOrder=y
                    }
                )
                .Where(x=>x.datosOrder.OrderId==10257);
                foreach(var item in productos)
                {
                    WriteLine("{0}\t{1,-30}\t{2}\t\t{3}",item.datosProd.ProductId,item.datosProd.ProductName,item.datosProd.UnitPrice,item.datosProd.UnitsInStock);
                }
            }
        }
        static void Ejercicio33()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Categorías productos precio y stock");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var productos=db.Products
                .Include(x=>x.Category)
                .ToList()
                .GroupBy(x=>x.Category);
                foreach(var item in productos)
                {
                    ForegroundColor=ConsoleColor.Cyan;
                    WriteLine($"CategoryID: {item.Key.CategoryId} CategoryName: {item.Key.CategoryName}");
                    ForegroundColor=ConsoleColor.White;
                    WriteLine("{0,-20}{1,-27}{2,-15}{3}","ProductID","ProductName","UnitPrice","Stock");
                    foreach(var d in item)
                    {
                        WriteLine("{0,-15}{1,-35}{2,-15}{3}",d.ProductId,d.ProductName,d.UnitPrice,d.UnitsInStock);
                    }
                }
            }
        }
        static void Ejercicio34()
        {
             ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Categorías productos precio y stock");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var productos=db.Products
                .Include(x=>x.Category)
                .ToList()
                .GroupBy(x=>x.Category);
                foreach(var item in productos)
                {
                    long? stock=item.Sum(x=>x.UnitsInStock);
                    ForegroundColor=ConsoleColor.Cyan;
                    WriteLine($"CategoryID: {item.Key.CategoryId}\tCategoryName {item.Key.CategoryName}");
                    ForegroundColor=ConsoleColor.White;
                    WriteLine("ProductID\tProductName\t\t\tStock");

                    foreach(var d in item)
                    {
                        WriteLine("{0,-10}{1,-35}{2}",d.ProductId,d.ProductName,d.UnitsInStock);
                    }
                    ForegroundColor=ConsoleColor.Red;
                    WriteLine($"STOCK TOTAL: {stock}");
                    ForegroundColor=ConsoleColor.White;
                }
            }
        }
        static void Ejercicio35()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("Clientes,Empleados,Proveedores,Productos de la orden 10794");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var productos=db.Orders
                .Where(x=>x.OrderId==10794)
                .Include(x=>x.OrderDetails)
                    .ThenInclude(x=>x.Product)
                        .ThenInclude(x=>x.Supplier)
                .Join(
                    db.Customers,
                    x=>x.CustomerId,
                    y=>y.CustomerId,
                    (x,y)=>new{
                        OPyS=x,
                        Clientes=y
                    }
                )
                .Join(
                    db.Employees,
                    x=>x.OPyS.EmployeeId,
                    y=>y.EmployeeId,
                    (x,y)=>new{
                        OPSyC=x,
                        Empleados=y
                    }
                );
                
                foreach(var item in productos)
                {
                    WriteLine($"Nombre Cliente: {item.OPSyC.Clientes.CompanyName}");
                    WriteLine($"Nombre Empleado: {item.Empleados.FirstName} {item.Empleados.LastName}\n");
                    foreach(var d in item.OPSyC.OPyS.OrderDetails)
                    {
                        WriteLine($"Nombre Proveedor: {d.Product.Supplier.CompanyName}");
                        WriteLine($"Producto: {d.Product.ProductName}\n");
                    }
                }
            }
        }
        static void Ejercicio36()
        {
            ForegroundColor=ConsoleColor.Yellow;
            WriteLine("CompañíaCliente,CódigoCompra,FechaCompra,CódigoProducto,CantidadProducto,NombreProducto,NombreProveedor,CiudadProveedor");
            ForegroundColor=ConsoleColor.White;
            using(var db=new NorthwindContext())
            {
                var clientes=db.Orders
                .Join(
                    db.Customers,
                    x=>x.CustomerId,
                    y=>y.CustomerId,
                    (x,y)=>new{
                        Ordenes=x,
                        Customers=y
                    }
                )
                .Join(
                    db.OrderDetails,
                    x=>x.Ordenes.OrderId,
                    y=>y.OrderId,
                    (x,y)=>new{
                        OrdenesyCustomers=x,
                        OrderDetails=y
                    }
                )
                .Join(
                    db.Products,
                    x=>x.OrderDetails.ProductId,
                    y=>y.ProductId,
                    (x,y)=>new{
                        DatosOrdenesyClientes=x,
                        Productos=y
                    }
                )
                .Join(
                    db.Suppliers,
                    x=>x.Productos.SupplierId,
                    y=>y.SupplierId,
                    (x,y)=>new{
                        Datos=x,
                        Proveedores=y
                    }
                )
                .Select( x=>new{
                        CompañiaCliente=x.Datos.DatosOrdenesyClientes.OrdenesyCustomers.Customers.CompanyName,
                        IdOrden=x.Datos.DatosOrdenesyClientes.OrderDetails.OrderId,
                        Fecha=x.Datos.DatosOrdenesyClientes.OrdenesyCustomers.Ordenes.OrderDate,
                        IdProducto=x.Datos.Productos.ProductId,
                        Cantidad=x.Datos.DatosOrdenesyClientes.OrderDetails.Quantity,
                        NombreProducto=x.Datos.Productos.ProductName,
                        CompañiaProveedor=x.Proveedores.CompanyName,
                        Ciudad=x.Proveedores.City,
                    });
                foreach(var item in clientes)
                {
                    WriteLine($"Compañía Cliente: {item.CompañiaCliente}");
                    WriteLine($"Orden ID: {item.IdOrden}");
                    WriteLine($"Fecha Orden: {item.Fecha.Value.ToString("dd/MM/yyyy")}");
                    WriteLine($"Producto ID: {item.IdProducto}");
                    WriteLine($"Cantidad: {item.Cantidad}");
                    WriteLine($"Nombre Producto: {item.NombreProducto}");
                    WriteLine($"Compañía Proveedora: {item.CompañiaProveedor}");
                    WriteLine($"Ciudad Proveedor: {item.Ciudad}\n");
                }
            }   
        }
   }
}
