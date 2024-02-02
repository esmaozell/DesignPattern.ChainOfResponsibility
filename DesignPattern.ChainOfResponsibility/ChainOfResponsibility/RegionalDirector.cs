using DesignPattern.ChainOfResponsibility.DataAcsessLayer;
using DesignPattern.ChainOfResponsibility.Models;

namespace DesignPattern.ChainOfResponsibility.ChainOfResponsibility
{
    public class RegionalDirector : Employee
    {
        Context context = new Context();
        public override void ProcessRequest(CustomerProcessViewModel req)
        {
            if (req.Amount <= 40000)
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = req.Amount.ToString(),
                    Name = req.Name,
                    EmployeeName = "Bölge Müdürü  - Esma Özel",
                    Description = "Para çekme işlemi onaylandı, müşteriye talep ettiği tutar ödendi",

                };

                context.Add(customerProcess);
                context.SaveChanges();
            }
            else
            {
                CustomerProcess customerProcess = new CustomerProcess
                {
                    Amount = req.Amount.ToString(),
                    Name = req.Name,
                    Description = "Para çekme tutarı bölge müdürünün günlük para çekme limitini aştığı için onaylanmadı",
                    EmployeeName = "Bölge Müdürü - Esma Özel"
                };
                context.CustomerProcesses.Add(customerProcess);
                context.SaveChanges();
            }
        }
    }
}
