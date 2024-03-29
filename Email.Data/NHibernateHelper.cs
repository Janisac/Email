﻿using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Cfg;

namespace Email.Data
{
    public class NHibernateHelper
    {
        private ISessionFactory _sessionFactory;
        public NHibernateHelper()
        {
            _sessionFactory = GetSessionFactory();
        }
        private ISessionFactory GetSessionFactory()
        {
            return (new Configuration()).Configure().BuildSessionFactory();
        }
        public ISession GetSession()
        {
            return _sessionFactory.OpenSession();
        }
    }
    public class UserHelper {
        public static string uEmail = "";
    }
}
