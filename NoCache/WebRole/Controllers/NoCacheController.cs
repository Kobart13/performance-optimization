﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using CachingDemo.Data;
using CachingDemo.Data.Models;

namespace WebRole.Controllers
{
    public class NoCacheController : ApiController
    {
        public async Task<IHttpActionResult> GetPerson(int id)
        {
            IPersonRepository repository = new PersonRepository();
            var person = await repository.GetAsync(id);

            if (person == null) return NotFound();
            return Ok(person);
        }

        public async Task<IHttpActionResult> GetCustomer(int id)
        {
            ICustomerRepository repository = new CustomerRepository();
            var customer = await repository.GetAsync(id);

            if (customer == null) return NotFound();
            return Ok(customer);
        }

        public async Task<IHttpActionResult> GetEmployee(int id)
        {
            IEmployeeRepository repository = new EmployeeRepository();
            var employee = await repository.GetAsync(id);

            if (employee == null) return NotFound();
            return Ok(employee);
        }

        public async Task<IHttpActionResult> GetTopTenSalesOrders()
        {
            ISalesOrderRepository repository = new SalesOrderRepository();
            var results = await repository.GetTopTenSalesOrdersAsync();

            if (results == null) return NotFound();
            return Ok(results);
        }

        public async Task<IHttpActionResult> GetTopTenSalesPeople()
        {
            ISalesPersonRepository repository = new SalesPersonRepository();
            var results = repository.GetTopTenSalesPeopleAsync();

            if (results == null) return NotFound();
            return Ok(results);
        }
    }
}