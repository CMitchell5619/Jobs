using System;
using System.Collections.Generic;
using System.Data;
using acontractorsTale.Models;
using Dapper;

namespace acontractorsTale.Repositories
{
    public class contractorsRepository
    {
        public readonly IDbConnection _db;

        public contractorsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<contractor> GetAll()
        {
            string sql = "SELECT * FROM contractors;";
            return _db.Query<contractor>(sql);
        }

        internal contractor GetById(int Id)
        {
            string sql = "SELECT * FROM contractors WHERE id = @Id;";
            return _db.QueryFirstOrDefault<contractor>(sql, new { Id });
        }

        internal IEnumerable<contractor> GetByjobId(int id)
        {
            string sql = @"
            SELECT
            k.*,
            c.*
            FROM contractors k
            JOIN jobs c ON k.jobId = c.id
            WHERE jobId = @id;";

            return _db.Query<contractor, job, contractor>(sql, (contractor, job) =>
            {
                contractor.job = job;
                return contractor;
            }, new { id }, splitOn: "id");

        }

        internal contractor Create(contractor newcontractor)
        {
            string sql = @"
            INSERT INTO contractors
            (name, description, kingdomCred, id, jobId)
            VALUES
            (@Name, @Description, @kingdomCred, @id, @jobId);
            SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newcontractor);
            newcontractor.Id = id;
            return newcontractor;
        }

        internal contractor Edit(contractor contractorToEdit)
        {
            string sql = @"
            UPDATE contractors
            SET
                name = @Name,
                description = @Description,
                kingdomCred = @KingdomCred,
                jobId = @jobId
            WHERE id = @Id;
            SELECT * FROM contractors WHERE id = @Id;";
            return _db.QueryFirstOrDefault<contractor>(sql, contractorToEdit);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM contractors WHERE id = @id;";
            _db.Execute(sql, new { id });
        }


    }


}