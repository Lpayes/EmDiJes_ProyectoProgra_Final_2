using Amazon.Rekognition;
using Amazon.Rekognition.Model;
using Amazon.Runtime;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace EmDijes1.Services
{
    public class ServicioRekognition
    {
        private readonly AmazonRekognitionClient _cliente;

        public ServicioRekognition(string accessKey, string secretKey, string region)
        {
            var credenciales = new BasicAWSCredentials(accessKey, secretKey);
            var configuracion = Amazon.RegionEndpoint.GetBySystemName(region);
            _cliente = new AmazonRekognitionClient(credenciales, configuracion);
        }

        public async Task<List<Emotion>> DetectarEmocionesDesdeStreamAsync(Stream imagen)
        {
            var request = new DetectFacesRequest
            {
                Image = new Amazon.Rekognition.Model.Image { Bytes = new MemoryStream(ReadFully(imagen)) },
                Attributes = new List<string> { "ALL" }
            };

            var response = await _cliente.DetectFacesAsync(request);

            return response.FaceDetails.Count > 0
                ? response.FaceDetails[0].Emotions
                : new List<Emotion>();
        }

        private byte[] ReadFully(Stream input)
        {
            using var ms = new MemoryStream();
            input.CopyTo(ms);
            return ms.ToArray();
        }
    }
}