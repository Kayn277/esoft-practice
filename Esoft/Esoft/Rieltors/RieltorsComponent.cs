using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;
using Newtonsoft.Json;
namespace Esoft.Rieltors
{
    class RieltorsComponent
    {
        RequestComponent<Rieltor> rieltorRequest;
        RequestComponent<Rieltor[]> rieltorsRequest;

        public RieltorsComponent()
        {
            Initilize();
        }

        void Initilize()
        {
            rieltorRequest = new RequestComponent<Rieltor>();
            rieltorsRequest = new RequestComponent<Rieltor[]>();
        }

        public Rieltor[] GetAll()
        {
            return rieltorsRequest.GetResponse("http://localhost:3000/rieltor/all");
        }

        public Rieltor GetById(int id)
        {
            return rieltorRequest.GetResponse("http://localhost:3000/rieltor/" + id);
        }

        public Rieltor Delete(int id)
        {
            return rieltorRequest.GetResponse($"http://localhost:3000/rieltor/" + id, "DELETE");
        }

        public Rieltor Update(Rieltor rieltor)
        {
            string data = JsonConvert.SerializeObject(rieltor).ToString();
            return rieltorRequest.GetResponse($"http://localhost:3000/rieltor/", "PUT", data);
        }

        public Rieltor PostClient(Rieltor rieltor)
        {
            string data = JsonConvert.SerializeObject(rieltor).ToString();
            return rieltorRequest.GetResponse("http://localhost:3000/rieltor", "POST", data);
        }

    }
}
