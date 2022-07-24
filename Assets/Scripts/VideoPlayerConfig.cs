using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class VideoPlayerConfig : MonoBehaviour
{
    #region Variables Visible
    [Header("Instances")]
    [SerializeField] private VideoPlayer vidPlayer;
    [SerializeField] private RawImage renderInstance;

    [Header("Video Clips")]
    [SerializeField] private VideoClip IntroClip;
    [SerializeField] private VideoClip VictoryClip;
    [SerializeField] private VideoClip DefeatClip;

    [Header("Render Textures")]
    [SerializeField] private RenderTexture FirstRenderTexture;
    [SerializeField] private RenderTexture SecondRenderTexture;
    #endregion

    #region Variables Invisible
    private GameObject Player;
    private bool playedEndClip = false;

    #endregion

    #region Unity Functions
    private void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); //get player from scene
        PlayClip(IntroClip, FirstRenderTexture); //start introduction
    }

    private void Update()
    {
        if (vidPlayer.isPlaying) //turn on render while playing video
            renderInstance.gameObject.SetActive(true);
        else
            renderInstance.gameObject.SetActive(false);

        HeartSystem hs = Player.GetComponent<HeartSystem>(); //instance of hearth system
        if (hs.life <= 0) //play defeat if player is dead
        {
            PlayClip(DefeatClip, SecondRenderTexture);
        }

        PlayerController pdc = Player.GetComponent<PlayerController>(); //instance of Player Destination Check
        if (pdc.playVictoryAnimation && !playedEndClip)
        {
            PlayClip(VictoryClip, FirstRenderTexture); //play victory anim
            playedEndClip = true;
        }
    }

    #endregion

    #region Functions

    private void PlayClip(VideoClip clipToPlay, RenderTexture texture)
    {
        vidPlayer.clip = clipToPlay; //set new video clip
        renderInstance.texture = texture;
        vidPlayer.targetTexture = texture; //set coresponding texture
        vidPlayer.Play();
    }

    #endregion
}
