using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DbBase
{
    public class DbBase
    {
        #region Singleton

        private static DbBase _instance = null;

        public DbBase()
        {
        }

        public static DbBase GetInstance()
        {
            if (_instance == null)
                _instance = new DbBase();

            return _instance;
        }
        #endregion

        #region Select

        public string GetAll<T>(T entity)
        {
            String Select = "";
            String Where = "";
            Type Object = typeof(T);
            PropertyInfo[] props = Object.GetProperties();
            StringBuilder sb = new StringBuilder();
            object valueOf = null;
            

            foreach (PropertyInfo prop in props)
            {

                valueOf = prop.GetValue(entity, null);
                string typeProp = prop.ToString().Replace(" " + prop.Name, "");

                if(!prop.Name.Equals("search"))
                {
                    if (String.IsNullOrEmpty(Select))
                    {
                        Select = "SELECT " + prop.Name + " ";
                    }
                    else
                    {
                        Select += " ," + prop.Name + " ";
                    }
                }
                if (typeProp.Contains("Int"))
                {
                    if (Convert.ToInt64(valueOf) > 0)
                    {
                        if (String.IsNullOrEmpty(Where))
                        {
                            Where = " WHERE " + prop.Name + " = " + valueOf + "";
                        }
                        else
                        {
                            Where += " AND " + prop.Name + " = " + valueOf + "";
                        }
                    }
                }
                else if (typeProp.Equals("System.String"))
                {
                    if (valueOf != null)
                    {
                        if (!String.IsNullOrEmpty(valueOf.ToString()))
                        {
                            if (String.IsNullOrEmpty(Where))
                            {
                                Where = " WHERE " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                            else
                            {
                                Where += " AND " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                        }
                    }

                }
                else if (typeProp.Contains("Date"))
                {
                    if (valueOf != null)
                    {
                        if (!String.IsNullOrEmpty(valueOf.ToString()))
                        {
                            if (String.IsNullOrEmpty(Where))
                            {
                                Where = " WHERE " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                            else
                            {
                                Where += " AND " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                        }
                    }

                }
            }

            Select += " FROM " + Object.Name + Where;
            return Select;
        }

        public string GetAll<T>(T entity, bool paged, int total, int page_quantity, int page_number)
        {
            String Select = "";
            String Where = "";
            Type Object = typeof(T);
            PropertyInfo[] props = Object.GetProperties();
            StringBuilder sb = new StringBuilder();
            object valueOf = null;


            foreach (PropertyInfo prop in props)
            {
                valueOf = prop.GetValue(entity, null);
                string typeProp = prop.ToString().Replace(" " + prop.Name, "");

                if (String.IsNullOrEmpty(Select))
                {
                    Select = "SELECT  " + prop.Name + " ";
                }
                else
                {
                    Select += " ," + prop.Name + " ";
                }

                if (typeProp.Contains("Int"))
                {
                    if (Convert.ToInt64(valueOf) > 0)
                    {
                        if (String.IsNullOrEmpty(Where))
                        {
                            Where = " WHERE " + prop.Name + " = " + valueOf + "";
                        }
                        else
                        {
                            Where += " AND " + prop.Name + " = " + valueOf + "";
                        }
                    }
                }
                else if (typeProp.Equals("System.String"))
                {
                    if (valueOf != null)
                    {
                        if (!String.IsNullOrEmpty(valueOf.ToString()))
                        {
                            if (String.IsNullOrEmpty(Where))
                            {
                                Where = " WHERE " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                            else
                            {
                                Where += " AND " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                        }
                    }

                }
                else if (typeProp.Contains("Date"))
                {
                    if (valueOf != null)
                    {
                        if (!String.IsNullOrEmpty(valueOf.ToString()))
                        {
                            if (String.IsNullOrEmpty(Where))
                            {
                                Where = " WHERE " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                            else
                            {
                                Where += " AND " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                        }
                    }

                }
            }

            Select += " FROM " + Object.Name + Where;

            if (paged)
            {
                int inicial = (page_number * page_quantity) - page_quantity + 1;
                int final = (page_number * page_quantity) + 1;
                Select = Select + " limit "+inicial.ToString() + ","+page_quantity.ToString();
            }

            return Select;
        }

        public string GetCount<T>(T entity)
        {
            String Select = "";
            String Where = "";
            Type Object = typeof(T);
            PropertyInfo[] props = Object.GetProperties();
            StringBuilder sb = new StringBuilder();
            object valueOf = null;


            foreach (PropertyInfo prop in props)
            {
                valueOf = prop.GetValue(entity, null);
                string typeProp = prop.ToString().Replace(" " + prop.Name, "");

                if (prop.Name.Contains("ID_"))
                    Select = "Select count(" + prop.Name + ")  as resultado ";

                if (typeProp.Contains("Int"))
                {
                    if (Convert.ToInt64(valueOf) > 0)
                    {
                        if (String.IsNullOrEmpty(Where))
                        {
                            Where = " WHERE " + prop.Name + " = " + valueOf + "";
                        }
                        else
                        {
                            Where += " AND " + prop.Name + " = " + valueOf + "";
                        }
                    }
                }
                else if (typeProp.Equals("System.String"))
                {
                    if (valueOf != null)
                    {
                        if (!String.IsNullOrEmpty(valueOf.ToString()))
                        {
                            if (String.IsNullOrEmpty(Where))
                            {
                                Where = " WHERE " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                            else
                            {
                                Where += " AND " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                        }
                    }

                }
                else if (typeProp.Contains("Date"))
                {
                    if (valueOf != null)
                    {
                        if (!String.IsNullOrEmpty(valueOf.ToString()))
                        {
                            if (String.IsNullOrEmpty(Where))
                            {
                                Where = " WHERE " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                            else
                            {
                                Where += " AND " + prop.Name + " = '" + valueOf.ToString() + "'";
                            }
                        }
                    }

                }
            }
            Select += " FROM " + Object.Name + Where;
            return Select;
        }

        #endregion

        #region Update

        public string Update<T>(T entity)
        {
            String Update = String.Empty;
            String Where = String.Empty;
            Type Object = typeof(T);
            PropertyInfo[] props = Object.GetProperties();
            StringBuilder sb = new StringBuilder();
            object valueOf = null;


            foreach (PropertyInfo prop in props)
            {
                valueOf = prop.GetValue(entity, null);
                string typeProp = prop.ToString().Replace(" " + prop.Name, "");

                if (prop.Name.ToUpper().Contains("ID_"))
                {
                    Where = "Where " + prop.Name + " = " + FormatType(typeProp, valueOf);
                }
                else
                {
                    if (String.IsNullOrEmpty(Update))
                    {
                        Update = "Update " + Object.Name + " SET " + prop.Name + " = " + FormatType(typeProp, valueOf) + " ";
                    }
                    else
                    {
                        Update += "," + prop.Name + " = " + FormatType(typeProp, valueOf) + " ";
                    }
                }

            }

            Update += Where;

            return Update;
        }

        #endregion

        #region Insert

        public string Insert<T>(T entity)
        {
            String Insert = String.Empty;
            String Values = String.Empty;
            Type Object = typeof(T);
            PropertyInfo[] props = Object.GetProperties();
            StringBuilder sb = new StringBuilder();
            object valueOf = null;


            foreach (PropertyInfo prop in props)
            {
                valueOf = prop.GetValue(entity, null);
                string typeProp = prop.ToString().Replace(" " + prop.Name, "");

                if (!prop.Name.ToUpper().Contains("ID_"))
                {
                    if (String.IsNullOrEmpty(Insert))
                    {
                        Insert = "Insert into " + Object.Name + " (" + prop.Name + "";
                        Values = ") Values (" + FormatType(typeProp, valueOf);
                    }
                    else
                    {
                        Insert += ", " + prop.Name;
                        Values += ", " + FormatType(typeProp, valueOf);
                    }
                }
            }
            Values += ");";
            Insert += Values;

            return Insert;
        }

        #endregion

        #region Delete

        public string Delete<T>(T entity)
        {
            String Delete = String.Empty;
            String Where = String.Empty;
            Type Object = typeof(T);
            PropertyInfo[] props = Object.GetProperties();
            StringBuilder sb = new StringBuilder();
            object valueOf = null;

            Delete = "Delete from " + Object.Name;

            foreach (PropertyInfo prop in props)
            {
                valueOf = prop.GetValue(entity, null);
                string typeProp = prop.ToString().Replace(" " + prop.Name, "");

                if (prop.Name.ToUpper().Contains("ID_"))
                {
                    Where = " Where " + prop.Name + " = " + FormatType(typeProp, valueOf);
                }
            }
            Delete += Where;

            return Delete;
        }

        #endregion

        #region Variable Type

        private string FormatType(string typeProp, object value)
        {
            if ((typeProp.ToUpper().Contains("INT")) || (typeProp.ToUpper().Contains("LONG")) || (typeProp.ToUpper().Contains("DOUBLE")))
                return "" + value + "";
            else if ((typeProp.ToUpper().Contains("STRING")) || (typeProp.ToUpper().Contains("CHAR")) || (typeProp.ToUpper().Contains("DATETIME")))
                return "'" + value + "'";
            else
                return
                    "";
        }
        #endregion
    }
}
