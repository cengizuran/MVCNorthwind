using MVCNotrhwindTekrar_1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCNotrhwindTekrar_1.DesignPatterns.SingletonPattern
{
    public class DBTool
    {
        static NorthwindEntities _dbInstance;

        DBTool()
        {

        }

        public static NorthwindEntities DBInstance 
        {
            get
            {
                if( _dbInstance == null ) _dbInstance = new NorthwindEntities();
                return _dbInstance;
            }
        }
    }
}