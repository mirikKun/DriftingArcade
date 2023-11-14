using Photon.Pun;

namespace Infrastructure
{
    public class PhotonSceneLoader
    {
        public void LoadScene(string name) =>
            PhotonNetwork.LoadLevel(name);

    }
}