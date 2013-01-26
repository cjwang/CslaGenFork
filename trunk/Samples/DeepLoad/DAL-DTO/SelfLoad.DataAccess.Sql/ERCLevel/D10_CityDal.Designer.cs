using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Csla;
using Csla.Data;
using SelfLoad.DataAccess;
using SelfLoad.DataAccess.ERCLevel;

namespace SelfLoad.DataAccess.Sql.ERCLevel
{
    /// <summary>
    /// DAL SQL Server implementation of <see cref="ID10_CityDal"/>
    /// </summary>
    public partial class D10_CityDal : ID10_CityDal
    {
        /// <summary>
        /// Inserts a new D10_City object in the database.
        /// </summary>
        /// <param name="d10_City">The D10 City DTO.</param>
        /// <returns>The new <see cref="D10_CityDto"/>.</returns>
        public D10_CityDto Insert(D10_CityDto d10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("AddD10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Region_ID", d10_City.Parent_Region_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_ID", d10_City.City_ID).Direction = ParameterDirection.Output;
                    cmd.Parameters.AddWithValue("@City_Name", d10_City.City_Name).DbType = DbType.String;
                    cmd.ExecuteNonQuery();
                    d10_City.City_ID = (int)cmd.Parameters["@City_ID"].Value;
                }
            }
            return d10_City;
        }

        /// <summary>
        /// Updates in the database all changes made to the D10_City object.
        /// </summary>
        /// <param name="d10_City">The D10 City DTO.</param>
        /// <returns>The updated <see cref="D10_CityDto"/>.</returns>
        public D10_CityDto Update(D10_CityDto d10_City)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("UpdateD10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", d10_City.City_ID).DbType = DbType.Int32;
                    cmd.Parameters.AddWithValue("@City_Name", d10_City.City_Name).DbType = DbType.String;
                    var rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected == 0)
                        throw new DataNotFoundException("D10_City");
                }
            }
            return d10_City;
        }

        /// <summary>
        /// Deletes the D10_City object from database.
        /// </summary>
        /// <param name="city_ID">The City ID.</param>
        public void Delete(int city_ID)
        {
            using (var ctx = ConnectionManager<SqlConnection>.GetManager("DeepLoad"))
            {
                using (var cmd = new SqlCommand("DeleteD10_City", ctx.Connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@City_ID", city_ID).DbType = DbType.Int32;
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
