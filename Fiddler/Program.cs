using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fiddler
{
    class Program
    {
        private static void Main(string[] args)
        {
            if (FiddlerApplication.IsStarted())
            {
                FiddlerApplication.Shutdown();
            }
            else
            {                
                FiddlerApplication.ResponseHeadersAvailable += FiddlerApplication_ResponseHeadersAvailable;
                FiddlerApplication.RequestHeadersAvailable += FiddlerApplication_RequestHeadersAvailable;
                FiddlerApplication.OnWebSocketMessage += FiddlerApplication_OnWebSocketMessage;
                FiddlerApplication.OnValidateServerCertificate += FiddlerApplication_OnValidateServerCertificate;
                FiddlerApplication.OnReadResponseBuffer += FiddlerApplication_OnReadResponseBuffer;
                FiddlerApplication.OnReadRequestBuffer += FiddlerApplication_OnReadRequestBuffer;
                FiddlerApplication.OnNotification += FiddlerApplication_OnNotification;
                FiddlerApplication.OnClearCache += FiddlerApplication_OnClearCache;
                FiddlerApplication.FiddlerDetach += FiddlerApplication_FiddlerDetach;
                FiddlerApplication.FiddlerAttach += FiddlerApplication_FiddlerAttach;
                FiddlerApplication.BeforeReturningError += FiddlerApplication_BeforeReturningError;
                FiddlerApplication.BeforeRequest += FiddlerApplication_BeforeRequest;
                FiddlerApplication.AfterSocketConnect += FiddlerApplication_AfterSocketConnect;
                FiddlerApplication.AfterSocketAccept += FiddlerApplication_AfterSocketAccept;
                FiddlerApplication.AfterSessionComplete += FiddlerApplication_AfterSessionComplete;
                
                FiddlerApplication.Startup(80, FiddlerCoreStartupFlags.DecryptSSL);

                Console.WriteLine("Fiddler is listening to Port:80");
                Console.WriteLine();

                Console.ReadKey();
            }
        }

        private static void FiddlerApplication_ResponseHeadersAvailable(Session oSession)
        {

        }

        private static void FiddlerApplication_RequestHeadersAvailable(Session oSession)
        {

        }

        private static void FiddlerApplication_OnWebSocketMessage(object sender, WebSocketMessageEventArgs e)
        {

        }

        private static void FiddlerApplication_OnValidateServerCertificate(object sender, ValidateServerCertificateEventArgs e)
        {

        }

        private static void FiddlerApplication_OnReadResponseBuffer(object sender, RawReadEventArgs e)
        {

        }

        private static void FiddlerApplication_OnReadRequestBuffer(object sender, RawReadEventArgs e)
        {

        }

        private static void FiddlerApplication_OnNotification(object sender, NotificationEventArgs e)
        {

        }

        private static void FiddlerApplication_OnClearCache(object sender, CacheClearEventArgs e)
        {

        }

        private static void FiddlerApplication_FiddlerDetach()
        {

        }

        private static void FiddlerApplication_FiddlerAttach()
        {

        }

        private static void FiddlerApplication_BeforeReturningError(Session oSession)
        {

        }

        private static void FiddlerApplication_BeforeRequest(Session oSession)
        {
            string method = oSession.RequestMethod;

            Console.WriteLine("              Method: " + method);

            foreach (HTTPHeaderItem item in oSession.RequestHeaders)
            {
                while (item.Name.Length != 20)
                {
                    item.Name = " " + item.Name;
                }

                Console.WriteLine(item.Name + ": " + item.Value);
            }

            Console.WriteLine();

            //if (oSession.HTTPMethodIs("CONNECT"))
            //{
            //    oSession["OriginalHostname"] = oSession.hostname;
            //    oSession.PathAndQuery = "www.facebook.com:443";
            //}

            //oSession.hostname = "www.facebook.com";

            //// If it's an HTTPS tunnel, override the certificate
            //if (oSession.HTTPMethodIs("CONNECT") && (null != oSession["OriginalHostname"]))
            //{
            //    oSession["x-overrideCertCN"] = oSession["OriginalHostname"];
            //    oSession["X-IgnoreCertCNMismatch"] = "Server's hostname may not match what we're expecting...";
            //}
            //oSession.bypassGateway = true;
        }

        private static void FiddlerApplication_AfterSocketConnect(object sender, ConnectionEventArgs e)
        {

        }

        private static void FiddlerApplication_AfterSocketAccept(object sender, ConnectionEventArgs e)
        {

        }

        private static void FiddlerApplication_AfterSessionComplete(Session oSession)
        {
            if (oSession.RequestMethod == "CONNECT")
            {
                
            }
        }
    }
}
