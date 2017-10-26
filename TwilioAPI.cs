using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace VendingMachineNew
{
    public class TwilioAPI
    {
        static void Main(string[] args)
        {
            SendSms().Wait();
            Console.Write("Press any key to continue.");
            Console.ReadKey();
        }

        static async Task SendSms()
        {
            // Your Account SID from twilio.com/console
            var accountSid = "x";
            // Your Auth Token from twilio.com/console
            var authToken = "x";

            TwilioClient.Init(accountSid, authToken);

            var message = await MessageResource.CreateAsync(
                to: new PhoneNumber("+14148070975"),
                from: new PhoneNumber("+14142693915"),
                body: "The confirmation number will be here");

            Console.WriteLine(message.Sid);
        }
    }
}
