using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Esoft
{
    class ClientComponent
    {
        RequestComponent<Client> clientRequest;
        RequestComponent<Client[]> clientsRequest;

        public ClientComponent()
        {
            Initilize();
        }

        void Initilize()
        {
            clientRequest = new RequestComponent<Client>();
            clientsRequest = new RequestComponent<Client[]>();
        }

        public Client[] GetAll()
        {
            return clientsRequest.GetResponse("http://localhost:3000/client/all");
        }

        public Client GetById(int id)
        {
            return clientRequest.GetResponse("http://localhost:3000/client/" + id);
        }

        public Client Delete(int id)
        {
            return clientRequest.GetResponse($"http://localhost:3000/client/" + id, "DELETE");
        }

        public Client Update(Client client)
        {
            string data = JsonConvert.SerializeObject(client).ToString();
            return clientRequest.GetResponse($"http://localhost:3000/client/" , "PUT", data);
        }

        public Client PostClient(Client client)
        {
            string data = JsonConvert.SerializeObject(client).ToString();
            return clientRequest.GetResponse("http://localhost:3000/client", "POST", data);
        }
    }
}
