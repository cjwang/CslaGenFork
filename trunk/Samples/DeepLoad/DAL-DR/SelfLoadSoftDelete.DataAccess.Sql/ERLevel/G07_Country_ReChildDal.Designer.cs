using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoadSoftDelete.DataAccess;
using SelfLoadSoftDelete.DataAccess.ERLevel;

namespace SelfLoadSoftDelete.DataAccess.Sql.ERLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IG07_Country_ReChildDal"/>
    /// </summary>
    public partial class G07_Country_ReChildDal : IG07_Country_ReChildDal
    {
        /// <summary>
        /// Loads a G07_Country_ReChild object from the database.
        /// </summary>
        /// <param name="country_ID2">The Country ID2.</param>
        /// <returns>A data reader to the G07_Country_ReChild.</returns>
        public IDataReader Fetch(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new G07_Country_ReChild object in the database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        public void Insert(int country_ID2, string country_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", country_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the G07_Country_ReChild object.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        /// <param name="country_Child_Name">The Country Child Name.</param>
        public void Update(int country_ID2, string country_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Country_Child_Name", country_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G07_Country_ReChild");
                }
            }
        }

        /// <summary>
        /// Deletes the G07_Country_ReChild object from database.
        /// </summary>
        /// <param name="country_ID2">The parent Country ID2.</param>
        public void Delete(int country_ID2)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG07_Country_ReChild", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Country_ID2", country_ID2).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
