using System;

namespace CodeGenerator.Utility
{
    /// <summary>
    /// Author：Kt
    /// Date Created：2011-04-01
    /// Description：方法对象-工具类
    /// </summary>
    public static class FunHelper
    {
        #region 获取值

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static string GetValue(object obj, string defaultValue)
        {
            return obj == null ? defaultValue : obj.ToString();
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static byte GetValue(object obj, byte defaultValue)
        {
            byte result = defaultValue;
            return (byte.TryParse(GetValue(obj, defaultValue.ToString()), out result)) ? result : defaultValue;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static int GetValue(object obj, int defaultValue)
        {
            int result = defaultValue;
            return (int.TryParse(GetValue(obj, defaultValue.ToString()), out result)) ? result : defaultValue;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static bool GetValue(object obj, bool defaultValue)
        {
            bool result = defaultValue;
            return (bool.TryParse(GetValue(obj, defaultValue.ToString()), out result)) ? result : defaultValue;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static long GetValue(object obj, long defaultValue)
        {
            long result = defaultValue;
            return (long.TryParse(GetValue(obj, defaultValue.ToString()), out result)) ? result : defaultValue;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static DateTime GetValue(object obj, DateTime defaultValue)
        {
            DateTime result = defaultValue;
            return (DateTime.TryParse(GetValue(obj, defaultValue.ToString()), out result)) ? result : defaultValue;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static double GetValue(object obj, double defaultValue)
        {
            double result = defaultValue;
            return (double.TryParse(GetValue(obj, defaultValue.ToString()), out result)) ? result : defaultValue;
        }

        /// <summary>
        /// 获取值
        /// </summary>
        /// <param name="obj">对象</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns></returns>
        public static decimal GetValue(object obj, decimal defaultValue)
        {
            decimal result = defaultValue;
            return (decimal.TryParse(GetValue(obj, defaultValue.ToString()), out result)) ? result : defaultValue;
        }

        #endregion 获取值
    }
}