using System.Linq;
using DeveloperTest.Business.Interfaces;
using DeveloperTest.Database;
using DeveloperTest.Database.Models;
using DeveloperTest.Models;

namespace DeveloperTest.Business
{
    public class JobService : IJobService
    {
        private readonly ApplicationDbContext context;

        public JobService(ApplicationDbContext context)
        {
            this.context = context;
        }

        public JobModel[] GetJobs()
        {
            var jobs = context.Jobs.Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerId = x.CustomerId
            }).ToList();

            var customerIds = jobs.Where(w => w.CustomerId > 0).Select(j => j.CustomerId).ToList();

            var customers = context.Customers.Where(c => customerIds.Contains(c.CustomerId)).ToList();

            foreach (var jEntry in jobs)
                if (jEntry.CustomerId > 0)
                    jEntry.Customer = customers.Where(c => c.CustomerId == jEntry.CustomerId).FirstOrDefault();

            return jobs.ToArray();
        }

        public JobModel GetJob(int jobId)
        {
            var job = context.Jobs.Where(x => x.JobId == jobId).Select(x => new JobModel
            {
                JobId = x.JobId,
                Engineer = x.Engineer,
                When = x.When,
                CustomerId = x.CustomerId
            }).SingleOrDefault();

            if (job != null && job.CustomerId > 0)
                job.Customer = context.Customers.Where(c => c.CustomerId == job.CustomerId).FirstOrDefault();

            return job;
        }

        public JobModel CreateJob(BaseJobModel model)
        {
            var customer = context.Customers.Where(c => c.CustomerId == model.CustomerId).FirstOrDefault();

            var addedJob = context.Jobs.Add(new Job
            {
                Engineer = model.Engineer,
                When = model.When,
                CustomerId = model.CustomerId,
                Customer = customer
            });

            context.SaveChanges();

            return new JobModel
            {
                JobId = addedJob.Entity.JobId,
                Engineer = addedJob.Entity.Engineer,
                When = addedJob.Entity.When,
                Customer = addedJob.Entity.Customer
            };
        }
    }
}
