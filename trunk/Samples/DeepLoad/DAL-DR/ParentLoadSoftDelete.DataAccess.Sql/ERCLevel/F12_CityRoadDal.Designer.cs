using System;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using ParentLoadSoftDelete.DataAccess;
using ParentLoadSoftDelete.DataAccess.ERCLevel;

namespace ParentLoadSoftDelete.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="IF12_CityRoadDal"/>
    /// </summary>
    public partial class F12_CityRoadDal : IF12_CityRoadDal
    {
        /// <summary>
        /// Inserts a new F12_CityRoad object in the database.
        /// </summary>
        /// <param name="parent_City_ID">The parent Parent City ID.</param>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        /// <param name="cityRoad_Name">The City Road Name.</param>
        public void Insert(int parent_City_ID, out int cityRoad_ID, string cityRoad_Name)
        {
            cityRoad_ID = -1;
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddF12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Parent_City_ID", parent_City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", cityRoad_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    cityRoad_ID = (int)cmd.Parameters["@CityRoad_ID"].Value;
                }
            }
        }

        /// <summary>
        /// Updates in the database all changes made to the F12_CityRoad object.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        /// <param name="cityRoad_Name">The City Road Name.</param>
        public void Update(int cityRoad_ID, string cityRoad_Name)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateF12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@CityRoad_Name", cityRoad_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("F12_CityRoad");
                }
            }
        }

        /// <summary>
        /// Deletes the F12_CityRoad object from database.
        /// </summary>
        /// <param name="cityRoad_ID">The City Road ID.</param>
        public void Delete(int cityRoad_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteF12_CityRoad", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CityRoad_ID", cityRoad_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
