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
    /// DAL SQL Server implementation of <see cref="IG03_Continent_ChildDal"/>
    /// </summary>
    public partial class G03_Continent_ChildDal : IG03_Continent_ChildDal
    {
        /// <summary>
        /// Loads a G03_Continent_Child object from the database.
        /// </summary>
        /// <param name="continent_ID1">The Continent ID1.</param>
        /// <returns>A data reader to the G03_Continent_Child.</returns>
        public IDataReader Fetch(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("GetG03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    return cmd.ExecuteReader();
                }
            }
        }

        /// <summary>
        /// Inserts a new G03_Continent_Child object in the database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        public void Insert(int continent_ID1, string continent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddG03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", continent_Child_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the G03_Continent_Child object.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        /// <param name="continent_Child_Name">The Continent Child Name.</param>
        public void Update(int continent_ID1, string continent_Child_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateG03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@Continent_Child_Name", continent_Child_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("G03_Continent_Child");
                }
            }
        }

        /// <summary>
        /// Deletes the G03_Continent_Child object from database.
        /// </summary>
        /// <param name="continent_ID1">The parent Continent ID1.</param>
        public void Delete(int continent_ID1)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteG03_Continent_Child", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Continent_ID1", continent_ID1).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
