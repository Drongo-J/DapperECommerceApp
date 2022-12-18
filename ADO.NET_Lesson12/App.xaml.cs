using ADO.NET_Lesson12.DataAccess.Abstractions;
using ADO.NET_Lesson12.DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ADO.NET_Lesson12
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IUnitOfWork DB;

        public App()
        {
            DB = new UnitOfWork();
        }
    }
}
