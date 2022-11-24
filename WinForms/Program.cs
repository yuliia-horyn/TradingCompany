﻿using AutoMapper;
using BLL.Concrete;
using BLL.Interfaces;
using DAL.Complete;
using DAL.Interfaces;
using DTO;
using System;
using System.Windows.Forms;
using Unity;

namespace WinForms
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        public static UnityContainer Container;
        public static int CurrentUserID;
        public static OrderDTO CurrentOrder;
        [STAThread]

        static void Main()
        {
            ConfigureUnity();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            LoginForm lf = Container.Resolve<LoginForm>();
            if (lf.ShowDialog() == DialogResult.OK)
            {
                
                Application.Run(Container.Resolve<OrdersForm>());
            }
            else
            { 
               
                Application.Exit();
            }
        }
        private static void ConfigureUnity()
        {
            MapperConfiguration config = new MapperConfiguration(
                cfg =>
                {
                    cfg.AddMaps(typeof(OrderDal).Assembly);
                });

            Container = new UnityContainer();
            Container.RegisterInstance<IMapper>(config.CreateMapper());
            Container.RegisterType<IUserDal, UserDal>()
                     .RegisterType<IOrderDal, OrderDal>()
                     .RegisterType<IShoesDal, ShoesDal>()
                     .RegisterType<IAuthentication, Authentication>()
                     .RegisterType<IRegistered, Registered>()
;

        }
    }
}
