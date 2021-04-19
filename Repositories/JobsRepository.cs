using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using acontractorsTale.Models;

namespace acontractorsTale.Repositories
{
    public class jobsRepository
    {
        private readonly IDbConnection _db;

        public jobsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<job> GetAll()
        {
            string sql = "SELECT * FROM jobs;";
            return _db.Query<job>(sql);
        }

        internal job GetById(int Id)
        {
            string sql = "SELECT * FROM jobs WHERE id = @Id;";
            return _db.QueryFirstOrDefault<job>(sql, new { Id });
        }

        internal job Create(job newjob)
        {
            string sql = @"
      INSERT INTO jobs
      (name, commander, id, defense)
      VALUES
      (@Name, @Commander, @Id, @Defense);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newjob);
            newjob.Id = id;
            return newjob;
        }

        internal job Edit(job updatedjob)
        {
            string sql = @"
      UPDATE jobs
      SET
        name = @Name,
        commander = @Commander,
        defense = @Defense
      WHERE id = @Id;
      SELECT * FROM jobs WHERE id = @Id;";
            job returnjob = _db.QueryFirstOrDefault<job>(sql, updatedjob);
            return returnjob;
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM jobs WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }
    }
}