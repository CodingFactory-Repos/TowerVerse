using UnityEngine;

public class PlayAudio : MonoBehaviour
{
    public AudioSource audioSource; // L'AudioSource contenant votre clip audio
    public float distanceThreshold = 5.0f; // La distance à laquelle l'audio sera joué
    public KeyCode keyboardKey = KeyCode.E; // La touche du clavier pour jouer l'audio
    public KeyCode controllerKey = KeyCode.JoystickButton0; // La touche de la manette pour jouer l'audio
    public Canvas canvas; // Le canvas contenant le texte

    void Update()
    {
        // Calculer la distance entre le joueur et l'objet
        float distance = Vector3.Distance(transform.position, Camera.main.transform.position);

        // Vérifier si le joueur est assez proche
        if (distance <= distanceThreshold)
        {
            // Afficher le texte
            canvas.enabled = true;

            // Vérifier si l'utilisateur a appuyé sur la touche spécifiée
            if (Input.GetKeyDown(keyboardKey) || Input.GetKeyDown(controllerKey))
            {
                // Jouer l'audio
                audioSource.Play();
            }

            // Faire tourner le texte vers la caméra horizontalement
            canvas.transform.LookAt(Camera.main.transform);

            // Faire tourner le texte à l'envers
            canvas.transform.Rotate(0, 180, 0);
        } else {
            // Cacher le texte
            canvas.enabled = false;
        }
    }
}