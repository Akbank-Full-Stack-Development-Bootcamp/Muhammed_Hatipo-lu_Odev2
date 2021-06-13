using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace WebApı.Model
{
    public class CarRepository
    {
        private string connectionString;

        public CarRepository()
        {
            connectionString = @"Server=(localdb)\Mssqllocaldb;Database=DataCar;Trusted_Connection=True;MultipleActiveResultSets=True";
        }

        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public void Add(Car car)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string TQuery = @"INSERT INTO Cars (BrandName,ColorName,ModelYear,Descriptions,CarImageDate,ImagePath) Values(@BrandName,@ColorName,@ModelYear,@Descriptions,@CarImageDate,@ImagePath)";
                dbConnection.Open();
                dbConnection.Execute(TQuery, car);
            }
        }

        public IEnumerable<Car> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string TQuery = @"Select * From Cars";
                dbConnection.Open();
                return dbConnection.Query<Car>(TQuery);
            }
        }

        public Car GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string TQuery = @"Select * From Cars Where CarId = @Id";
                dbConnection.Open();
                return dbConnection.Query<Car>(TQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string TQuery = @"DELETE FROM Cars Where CarId = @Id";
                dbConnection.Open();
                dbConnection.Execute(TQuery, new { Id = id });
            }
        }

        public void Update(Car car)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string TQuery = @"UPDATE Cars SET BrandName=@BrandName, ColorName=@ColorName,
                                                      ModelYear=@ModelYear ,Descriptions = @Descriptions, CarImageDate=@CarImageDate, ImagePath=@ImagePath";
                dbConnection.Open();
                dbConnection.Query(TQuery, car);
            }
        }
    }
}
