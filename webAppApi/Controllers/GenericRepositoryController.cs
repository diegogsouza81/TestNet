using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using webAppApi.Models;
using webAppApi.Repository;

namespace webAppApi.Controllers
{
    public class GenericRepositoryController : ApiController
    {
        private IGenericRepository<Pessoa> repository = null;
        public GenericRepositoryController()
        {
            this.repository = new GenericRepository<Pessoa>();
        }
        public GenericRepositoryController(IGenericRepository<Pessoa> repository)
        {
            this.repository = repository;
        }


        // GET: api/GenericRepository
        [HttpGet]
        public IQueryable<Pessoa> Index()
        {
            return repository.GetAll();
            
        }
       
    }
}
