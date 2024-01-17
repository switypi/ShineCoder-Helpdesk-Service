using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using ShineCoder_Helpdesk.Infrastructure;
using ShineCoder_Helpdesk.Infrastructure.Models;

namespace ShineCoder_Helpdesk.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {

        internal HelpdeskDbContext context;
        public UnitOfWork(IHelpdeskDbContext _context)
        {

            this.context = _context as HelpdeskDbContext;
        }

        public IDbContextTransaction GetDbTransaction
        {
            get
            {
                return this.context.Database.BeginTransaction();
            }
        }
        public IHelpdeskDbContext GetDbContext
        {
            get
            {
                return this.context;
            }
        }
        // private SchoolContext context = new SchoolContext();
        private GenericRepository<Tickets> ticketRepository;
        private GenericRepository<Ticket_Priorities> ticketPrioritiesRepository;
        private GenericRepository<Ticket_Solutions> ticketSolutionsRepository;
        private GenericRepository<Ticket_Status> ticketStatusRepository;
        private GenericRepository<Ticket_Mode> ticketModeRepository;

        private GenericRepository<Category> categoryRepository;
        private GenericRepository<SubCategory> subCategoryRepository;
        private GenericRepository<Location> locationRepository;
        private GenericRepository<Department> departmentRepository;
        private GenericRepository<RequestType> requesttypeRepository;
        private GenericRepository<Product> productRepository;
        private GenericRepository<Ticket_Impact> impactRepository;
        private GenericRepository<Ticket_Urgency> urgencyRepository;
        private GenericRepository<Ticket_Level> ticketLevelRepository 
        public GenericRepository<Tickets> TicketRepository
        {
            get
            {

                if (this.ticketRepository == null)
                {
                    this.ticketRepository = new GenericRepository<Tickets>(context);
                }
                return ticketRepository;
            }
        }


        public GenericRepository<Ticket_Priorities> TicketPrioritiesRepository
        {
            get
            {

                if (this.ticketPrioritiesRepository == null)
                {
                    this.ticketPrioritiesRepository = new GenericRepository<Ticket_Priorities>(context);
                }
                return ticketPrioritiesRepository;
            }
        }

        public GenericRepository<Ticket_Solutions> TicketSolutionsRepository
        {
            get
            {

                if (this.ticketSolutionsRepository == null)
                {
                    this.ticketSolutionsRepository = new GenericRepository<Ticket_Solutions>(context);
                }
                return ticketSolutionsRepository;
            }
        }

        public GenericRepository<Ticket_Status> TicketStatusRepository
        {
            get
            {

                if (this.ticketStatusRepository == null)
                {
                    this.ticketStatusRepository = new GenericRepository<Ticket_Status>(context);
                }
                return ticketStatusRepository;
            }
        }

        public GenericRepository<Category> CategorysRepository
        {
            get
            {

                if (this.categoryRepository == null)
                {
                    this.categoryRepository = new GenericRepository<Category>(context);
                }
                return categoryRepository;
            }
        }

        public GenericRepository<SubCategory> SubCategorysRepository
        {
            get
            {

                if (this.subCategoryRepository == null)
                {
                    this.subCategoryRepository = new GenericRepository<SubCategory>(context);
                }
                return subCategoryRepository;
            }
        }

        public GenericRepository<Department> DepartmentRepository
        {
            get
            {

                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(context);
                }
                return departmentRepository;
            }
        }

        public GenericRepository<Location> LocationRepository
        {
            get
            {

                if (this.locationRepository == null)
                {
                    this.locationRepository = new GenericRepository<Location>(context);
                }
                return locationRepository;
            }
        }

        public GenericRepository<RequestType> RequestTypeRepository
        {
            get
            {

                if (this.requesttypeRepository == null)
                {
                    this.requesttypeRepository = new GenericRepository<RequestType>(context);
                }
                return requesttypeRepository;
            }
        }

        public GenericRepository<Ticket_Mode> TicketModeRepository
        {
            get
            {

                if (this.ticketModeRepository == null)
                {
                    this.ticketModeRepository = new GenericRepository<Ticket_Mode>(context);
                }
                return ticketModeRepository;
            }
        }

        public GenericRepository<Product> ProductRepository
        {
            get
            {

                if (this.productRepository == null)
                {
                    this.productRepository = new GenericRepository<Product>(context);
                }
                return productRepository;
            }
        }
        public GenericRepository<Ticket_Impact> ImpactRepository
        {
            get
            {

                if (this.impactRepository == null)
                {
                    this.impactRepository = new GenericRepository<Ticket_Impact>(context);
                }
                return impactRepository;
            }
        }
        public GenericRepository<Ticket_Urgency> UrgencyRepository
        {
            get
            {

                if (this.urgencyRepository == null)
                {
                    this.urgencyRepository = new GenericRepository<Ticket_Urgency>(context);
                }
                return urgencyRepository;
            }
        }

        public GenericRepository<Ticket_Level> TicketLevelRepository
        {
            get
            {

                if (this.ticketLevelRepository == null)
                {
                    this.ticketLevelRepository = new GenericRepository<Ticket_Level>(context);
                }
                return ticketLevelRepository;
            }
        }





        public async Task<int> SaveAsync()
        {
            return await context.SaveChangesAsync();
        }

        public void Rollback()
        {
            foreach (var entry in context.ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.State = EntityState.Detached;
                        break;
                }
            }
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
