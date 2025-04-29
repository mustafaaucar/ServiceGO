using DAL.ApplicationDbContext;
using DAL.BaseRepository;
using DAL.IRepositories;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        private readonly AppDbContext _context;
        public PaymentRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Payment> GetPayment(int driverID, int companyID)
        {
            try
            {
                var payment = await (from cd in _context.CompanyDrivers
                                     join p in _context.Payment on cd.DriverID equals p.Id
                                     where cd.DriverID == driverID && cd.CompanyID == companyID
                                     select p).FirstOrDefaultAsync();
                return payment;
            }
            catch (Exception)
            {
                Payment payment = new Payment();
                return payment;
            }
            
        }

    }
}
