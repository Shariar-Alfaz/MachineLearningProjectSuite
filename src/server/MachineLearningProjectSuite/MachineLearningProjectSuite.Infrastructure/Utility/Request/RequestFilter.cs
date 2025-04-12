using System.Text;
using MachineLearningProjectSuite.Application.Utility.Request;
using Microsoft.AspNetCore.Http;

namespace MachineLearningProjectSuite.Infrastructure.Utility.Request
{
    public class RequestFilter(IHttpContextAccessor http) : IRequestFilter
    {
        private HttpContext Context => http.HttpContext;

        private int Length => Convert.ToInt32(Context.Request.Query["length"]);

        public string Search => Context.Request.Query["search"];

        public int PageSize => Length > 0 ? Length : 10;

        public string SortColumn
        {
            get
            {
                string text = $"{Context.Request.Query["sortColumn"]} {Context.Request.Query["sortOrder"]}".Trim();
                if (text == "asc" || text == "desc" || text.Contains("null"))
                    return "";
                return text;
            }
        }

        public int Skip
        {
            get
            {
                if (Context.Request.Query["skip"] == "")
                    return 0;
                return Convert.ToInt32(Context.Request.Query["skip"]);
            }
        }

        public string Filter => Context.Request.Query["filter"];

        public DateTime? StartDate
        {
            get
            {
                try
                {
                    if (Context.Request.Query["startDate"] == "")
                        return null;
                    return DateTime.Parse(Context.Request.Query["startDate"]);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public DateTime? EndDate
        {
            get
            {
                try
                {
                    if (Context.Request.Query["endDate"] == "")
                        return null;
                    return DateTime.Parse(Context.Request.Query["endDate"]);
                }
                catch (Exception)
                {
                    return null;
                }
            }
        }

        public string NestedOrder
        {
            get
            {
                StringBuilder sb = new();
                string? columns = Context.Request.Query["orderColumns"];
                if (string.IsNullOrEmpty(columns)) return "";
                string? orders = Context.Request.Query["sortOrders"];
                if (string.IsNullOrEmpty(orders)) return "";
                if (columns.StartsWith(',')) columns = columns.Remove(0, 1);
                if (orders.StartsWith(',')) orders = orders.Remove(0, 1);
                var lc = columns.Trim().Split(',');
                var o = orders.Trim().Split(',');
                for (int i = 0; i < lc.Length; i++)
                {
                    sb.Append($"{lc[i]} {o[i]}, ");
                }

                var s = sb.ToString().Trim();
                return s.Remove(s.Length - 1, 1);
            }
        }

        public T GetData<T>(string key)
            where T : IComparable
        {
            var data = Context.Request.Query[key];
            if (string.IsNullOrEmpty(data))
                return default;
            try
            {
                return (T)Convert.ChangeType(data.ToString(), typeof(T));
            }
            catch
            {
                return default;
            }
        }
    }
}
