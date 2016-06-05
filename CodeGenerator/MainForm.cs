using CodeGenerator.Model;
using CodeGenerator.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CodeGenerator
{
    public partial class MainForm : Form
    {
        #region Windows 事件

        public MainForm()
        {
            InitializeComponent();
            FormLoad();
        }

        private void BtnGenerator_Click(object sender, EventArgs e)
        {
            GeneratorCode();
        }

        private void BtnRefresh_Click(object sender, System.EventArgs e)
        {
            try
            {
                BindDataTableName();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void DataTableNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (DataTableNames.SelectedItem != null)
                BindTableName(DataTableNames.SelectedItem.ToString());
        }

        private void FormLoad()
        {
            try
            {
                TxtSavePath.Text = ConfigHelper.GetValue("SavePath");
                TxtNamespace.Text = ConfigHelper.GetValue("Namespace");
                TxtClassName.Text = ConfigHelper.GetValue("ClassName");
                TxtExtends.Text = ConfigHelper.GetValue("Extends");
                EFBool.SelectedIndex = 0;
                SNTBool.SelectedIndex = 0;
                BindDataTableName();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        #endregion Windows 事件

        #region 属性

        public static string SqlConnString { get; set; }

        #endregion 属性

        #region 方法

        private void BindDataTableName()
        {
            ClearDataTable();
            if (UpdateSqlConn())
            {
                var tableNames = GetDataTableNames();
                foreach (var name in tableNames)
                {
                    DataTableNames.Items.Add(name);
                }
                if (DataTableNames.Items.Count > 0)
                {
                    DataTableNames.SelectedItem = DataTableNames.Items[0];
                }
            }
        }

        private void BindTableName(string dbName)
        {
            TableNames.Items.Clear();
            var tableNames = GetTableNames(dbName);
            foreach (var name in tableNames)
            {
                TableNames.Items.Add(name, true);
            }
        }

        private bool CheckSqlConnIsOpen()
        {
            try
            {
                var sqlcon = new SqlConnection(SqlConnString);
                sqlcon.Open();
                return sqlcon.State.ToString() == "Open";
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private void ClearDataTable()
        {
            DataTableNames.Items.Clear();
            TableNames.Items.Clear();
        }

        private string DBTypeToCSharpType(string type, bool allowNull, bool supportNullType)
        {
            var suffix = supportNullType && allowNull ? "?" : "";
            switch (type.ToLower())
            {
                case "int":
                    return "Int32" + suffix;

                case "text":
                    return "String";

                case "bigint":
                    return "Int64" + suffix;

                case "binary":
                    return "Byte[]" + suffix;

                case "bit":
                    return "Boolean" + suffix;

                case "char":
                    return "String";

                case "datetime":
                    return "DateTime" + suffix;

                case "decimal":
                    return "Decimal" + suffix;

                case "float":
                    return "Double" + suffix;

                case "image":
                    return "Byte[]" + suffix;

                case "money":
                    return "Decimal" + suffix;

                case "nchar":
                    return "String";

                case "ntext":
                    return "String";

                case "numeric":
                    return "Decimal" + suffix;

                case "nvarchar":
                    return "String";

                case "real":
                    return "Single" + suffix;

                case "smalldatetime":
                    return "DateTime" + suffix;

                case "smallint":
                    return "Int16" + suffix;

                case "smallmoney":
                    return "Decimal" + suffix;

                case "timestamp":
                    return "DateTime" + suffix;

                case "tinyint":
                    return "Byte" + suffix;

                case "uniqueidentifier":
                    return "Guid" + suffix;

                case "varbinary":
                    return "Byte[]" + suffix;

                case "varchar":
                    return "String";

                case "Variant":
                    return "Object" + suffix;

                default:
                    return "Object";
            }
        }

        private List<TableObj> DeserializeObject(DataTable dt)
        {
            var lst = new List<TableObj> { };
            if (dt != null)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    lst.Add(new TableObj
                    {
                        AllowNull = dr["AllowNull"] + "" == "1",
                        Description = FunHelper.GetValue(dr["Description"], ""),
                        Length = FunHelper.GetValue(dr["Length"], 0),
                        Name = FunHelper.GetValue(dr["Name"], ""),
                        Type = FunHelper.GetValue(dr["Type"], "")
                    });
                }
            }
            return lst;
        }

        private void GeneratorCode()
        {
            if (VerifySetInfo())
            {
                try
                {
                    var dbName = DataTableNames.SelectedItem.ToString();
                    var tableNames = GetCheckedTableNames();
                    foreach (var tableName in tableNames)
                    {
                        var sql = GetQuerySqlString(dbName, tableName);
                        var dt = GetTable(sql);
                        var lstObj = DeserializeObject(dt);
                        SaveFile(tableName, lstObj);
                    }
                    MessageBox.Show("全部生成成功！");
                    Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                    config.AppSettings.Settings["SavePath"].Value = TxtSavePath.Text;
                    config.AppSettings.Settings["Namespace"].Value = TxtNamespace.Text;
                    config.AppSettings.Settings["ClassName"].Value = TxtClassName.Text;
                    config.AppSettings.Settings["Extends"].Value = TxtExtends.Text;

                    config.Save(ConfigurationSaveMode.Modified);
                    ConfigurationManager.RefreshSection("appSettings");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private List<string> GetCheckedTableNames()
        {
            List<string> tableNames = new List<string>();
            for (int i = 0; i < TableNames.Items.Count; i++)
            {
                if (TableNames.GetItemChecked(i))
                {
                    tableNames.Add(TableNames.Items[i].ToString());
                }
            }
            return tableNames;
        }

        private List<string> GetDataTableNames()
        {
            List<string> result = new List<string>();
            try
            {
                DataTable dt = GetTable(" Select * From sysdatabases ");
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var tableName = dr["name"].ToString();
                        result.Add(tableName);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        private string GetQuerySqlString(string dbName, string tableName)
        {
            StringBuilder str = new StringBuilder();
            str.AppendFormat("use {0} ", dbName + Environment.NewLine);
            str.Append("Select C.name as 'Name', T.name as 'Type', C.length as 'Length',C.isnullable as 'AllowNull',cast(EP.[value] as varchar(max)) as 'Description' ");
            str.Append("From Syscolumns as C ");
            str.Append("INNER JOIN Systypes as T on C.xtype=T.xtype ");
            str.Append("LEFT JOIN sys.extended_properties as EP on EP.major_id = C.id and EP.minor_id=C.colid ");
            str.AppendFormat("Where T.name <> 'sysname' and C.id=object_id('{0}') ", tableName);
            return str.ToString();
        }

        private DataTable GetTable(string sql)
        {
            DataTable dt = null;
            try
            {
                DataSet ds = SqlHelper.ExecuteDataset(SqlConnString, CommandType.Text, sql);
                dt = (ds.Tables != null && ds.Tables.Count > 0) ? ds.Tables[0] : null;
                return dt;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private List<string> GetTableNames(string dbName)
        {
            List<string> result = new List<string>();
            try
            {
                DataTable dt = GetTable(string.Format("use {0}  Select name From sysobjects Where  type='u'; ", dbName));
                if (dt != null)
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var tableName = dr["name"].ToString();
                        result.Add(tableName);
                    }
                }

                return result;
            }
            catch (Exception ex)
            {
                return result;
            }
        }

        private void SaveFile(string tableName, List<TableObj> lstObj)
        {
            var filePath = TxtSavePath.Text + (TxtSavePath.Text.EndsWith(@"\") ? "" : @"\") + string.Format(TxtClassName.Text, tableName) + ".cs";
            var encapsulateFieId = EFBool.SelectedItem.ToString() == "True";
            var supportNullType = SNTBool.SelectedItem.ToString() == "True";

            #region C# 类文件格式

            StringBuilder content = new StringBuilder();
            content.Append("using System;");
            content.Append(Environment.NewLine);
            content.Append(Environment.NewLine);
            content.AppendFormat("namespace {0}", TxtNamespace.Text);
            content.Append(Environment.NewLine);
            content.Append("{");
            content.Append(Environment.NewLine);
            content.AppendFormat("    public class {0}", tableName + (string.IsNullOrEmpty(TxtExtends.Text) ? "" : " : " + TxtExtends.Text));
            content.Append(Environment.NewLine);
            content.Append("    {");
            content.Append(Environment.NewLine);
            content.AppendFormat("        public {0}()", tableName);
            content.Append(Environment.NewLine);
            content.Append("        {");
            content.Append(Environment.NewLine);
            content.Append("        }");
            content.Append(Environment.NewLine);
            content.Append(Environment.NewLine);

            content.Append("        #region 属性");
            content.Append(Environment.NewLine);
            content.Append(Environment.NewLine);
            foreach (var obj in lstObj)
            {
                if (encapsulateFieId)
                {
                    content.Append("        /// <summary>");
                    content.Append(Environment.NewLine);
                    content.AppendFormat("        /// {0}", obj.Description);
                    content.Append(Environment.NewLine);
                    content.Append("        /// </summary>");
                    content.Append(Environment.NewLine);
                    content.AppendFormat("        private {0} _{1} {2}", DBTypeToCSharpType(obj.Type, obj.AllowNull, supportNullType), obj.Name, " { get; set; }");
                    content.Append(Environment.NewLine);
                    content.Append(Environment.NewLine);

                    content.Append("        /// <summary>");
                    content.Append(Environment.NewLine);
                    content.AppendFormat("        /// {0}", obj.Description);
                    content.Append(Environment.NewLine);
                    content.Append("        /// </summary>");
                    content.Append(Environment.NewLine);
                    content.AppendFormat("        public {0} {1}", DBTypeToCSharpType(obj.Type, obj.AllowNull, supportNullType), obj.Name);
                    content.Append(Environment.NewLine);
                    content.Append("        {");
                    content.Append(Environment.NewLine);
                    content.Append("            get { return _" + obj.Name + "; }");
                    content.Append(Environment.NewLine);
                    content.Append("            set { " + obj.Name + " = value; }");
                    content.Append(Environment.NewLine);
                    content.Append("        }");
                    content.Append(Environment.NewLine);
                    content.Append(Environment.NewLine);
                }
                else
                {
                    content.Append("        /// <summary>");
                    content.Append(Environment.NewLine);
                    content.AppendFormat("        /// {0}", obj.Description);
                    content.Append(Environment.NewLine);
                    content.Append("        /// </summary>");
                    content.Append(Environment.NewLine);
                    content.AppendFormat("        public {0} {1} {2}", DBTypeToCSharpType(obj.Type, obj.AllowNull, supportNullType), obj.Name, " { get; set; }");
                    content.Append(Environment.NewLine);
                    content.Append(Environment.NewLine);
                }
            }
            content.Append("        #endregion 属性");
            content.Append(Environment.NewLine);
            content.Append("    }");
            content.Append(Environment.NewLine);
            content.Append("}");

            #endregion C# 类文件格式

            var folderPath = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(folderPath))
                Directory.CreateDirectory(folderPath);

            if (File.Exists(filePath))
                File.Delete(filePath);

            File.AppendAllText(filePath, content.ToString(), Encoding.UTF8);
        }

        private bool UpdateSqlConn()
        {
            try
            {
                SqlConnString = ConfigHelper.GetValue("SqlConnString");
                if (string.IsNullOrEmpty(SqlConnString))
                    new Exception("请在app.config文件中配置SqlConnString");

                if (!CheckSqlConnIsOpen())
                    new Exception("数据库连接失败");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        private bool VerifySetInfo()
        {
            try
            {
                if (string.IsNullOrEmpty(TxtSavePath.Text))
                    throw new Exception("SavePath Is Null");

                if (!Directory.Exists(TxtSavePath.Text))
                    Directory.CreateDirectory(TxtSavePath.Text);

                if (string.IsNullOrEmpty(TxtNamespace.Text))
                    throw new Exception("Namespace Is Null");

                if (string.IsNullOrEmpty(TxtClassName.Text))
                    throw new Exception("Class Name Is Null");

                if (DataTableNames.SelectedItem == null)
                    throw new Exception("DB Is Null");

                var tableNames = GetCheckedTableNames();

                if (tableNames.Count <= 0)
                    throw new Exception("Selected Table Is Null");

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #endregion 方法
    }
}