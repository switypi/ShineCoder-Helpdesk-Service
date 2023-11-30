using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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
		// private SchoolContext context = new SchoolContext();
		private GenericRepository<Tickets> ticketRepository;
		private GenericRepository<Ticket_Issues> ticketIssuesRepository;
		private GenericRepository<Ticket_Priorities> ticketPrioritiesRepository;
		private GenericRepository<Ticket_Solutions> ticketSolutionsRepository;

		private GenericRepository<Ticket_Status> ticketStatusRepository;
		//private GenericRepository<Ticket_Issues> courseRepository;

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

		public GenericRepository<Ticket_Issues> TicketIssuesRepository
		{
			get
			{

				if (this.ticketIssuesRepository == null)
				{
					this.ticketIssuesRepository = new GenericRepository<Ticket_Issues>(context);
				}
				return ticketIssuesRepository;
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

		public void Save()
		{
			context.SaveChanges();
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
