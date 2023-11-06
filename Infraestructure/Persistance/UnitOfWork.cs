﻿namespace GADistribuidora.Infraestructure.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GADistribuidoraContext _context;

        public UnitOfWork(GADistribuidoraContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();    
        }
    }
}
