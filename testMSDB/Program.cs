﻿using AdoNetLib;
using Microsoft.Data.SqlClient;
using System.Data;

namespace testMSDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var connector = new MainConnector();

            var result = connector.ConnectAsync();

            var data = new DataTable();

            if (result.Result)
            {
                Console.WriteLine("Подключено успешно!");

                var db = new DbExecutor(connector);
                
                var tablename = "NetworkUser";

                Console.WriteLine("Получаем данные таблицы " + tablename);


                data = db.SelectAll(tablename);
                Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

                Console.WriteLine("Отключаем БД!");
                connector.DisconnectAsync();
                Console.WriteLine("Количество строк в " + tablename + ": " + data.Rows.Count);

                foreach (DataColumn column in data.Columns)
                {
                    Console.Write($"{column.ColumnName}\t");
                }
                Console.WriteLine();

                foreach (DataRow row in data.Rows)
                {
                    var cells = row.ItemArray;
                    foreach (var cell in cells)
                    {
                        Console.Write($"{cell}\t");
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Ошибка подключения!");
            }

            Console.ReadKey();

        }
    }
}
