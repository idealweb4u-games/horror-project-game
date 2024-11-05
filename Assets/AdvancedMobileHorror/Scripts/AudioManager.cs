using UnityEngine;

namespace AdvancedHorrorFPS
{
    public class AudioManager : MonoBehaviour
    {
        public static AudioManager Instance;
        public AudioClip[] Door_Wooden_Open;
        public AudioClip[] Door_Close;
        public AudioClip Door_IsOpening;
        public AudioClip Door_IsClosing;
        public AudioClip[] PlayerShock;
        public AudioClip Door_TryOpen;
        public AudioClip Door_UnLock;
        public AudioClip Item_Grab;
        public AudioClip Flashlight;
        public AudioClip Audio_Breathing;
        public AudioClip Audio_TreasureOpen;
        public AudioClip Note_Reading;
        public AudioClip Item_Close;
        public AudioClip Audio_Jump;
        public AudioClip Audio_PadlockTry;
        public AudioClip Audio_Cabinet_Open;
        public AudioClip Audio_Drawer_Open;
        public AudioClip Audio_Hit_With_Weapon;
        public AudioClip Audio_Monster_Pain;
        public AudioClip Audio_Clown_Pain;
        public AudioClip[] Audio_DemonKilling;
        public AudioClip[] Audio_WoodBreakable;
        public AudioSource audioSource;
        public AudioSource audioSourceWalk;
        public AudioSource audioSourcePriest;
        public AudioSource[] audioSourceClownLaugh;

        private void Awake()
        {
            Instance = this;
        }

        void Start()
        {
            audioSource = GetComponent<AudioSource>();
        }

        public void Play_Jump()
        {
            audioSource.PlayOneShot(Audio_Jump);
        }

        public void Play_WoodBreakable()
        {
            audioSource.PlayOneShot(Audio_WoodBreakable[UnityEngine.Random.Range(0, Audio_WoodBreakable.Length)]);
        }

        public void Play_PlayerShock()
        {
            audioSource.PlayOneShot(PlayerShock[UnityEngine.Random.Range(0, PlayerShock.Length)]);
        }

        public void Play_PadlockTry()
        {
            audioSource.PlayOneShot(Audio_PadlockTry);
        }

        public void Play_TreasureOpen()
        {
            audioSource.PlayOneShot(Audio_TreasureOpen);
        }

        public void Play_Audio_Cabinet_Open()
        {
            audioSource.PlayOneShot(Audio_Cabinet_Open);
        }

        public void Play_Audio_Drawer_Open()
        {
            audioSource.PlayOneShot(Audio_Drawer_Open);
        }
        

        public void Play_Door_Wooden_Open()
        {
            audioSource.PlayOneShot(Door_Wooden_Open[UnityEngine.Random.Range(0, Door_Wooden_Open.Length)]);
        }

        public void Play_Audio_Breathing()
        {
            audioSource.PlayOneShot(Audio_Breathing);
        }

        public void Play_Door_Close()
        {
            audioSource.PlayOneShot(Door_Close[UnityEngine.Random.Range(0, Door_Close.Length)]);
        }

        public void Play_Door_SelfOpen()
        {
            audioSource.PlayOneShot(Door_IsOpening);
        }
        public void Play_Door_SelfClose()
        {
            audioSource.PlayOneShot(Door_IsClosing);
        }

        public void Play_Note_Reading()
        {
            audioSource.PlayOneShot(Note_Reading);
        }

        public void Play_Item_Close()
        {
            audioSource.PlayOneShot(Item_Close);
        }

        public void Play_Door_UnLock()
        {
            audioSource.PlayOneShot(Door_UnLock);
        }

        public void Play_Item_Grab()
        {
            audioSource.PlayOneShot(Item_Grab);
        }

        public void Play_Flashlight_Open()
        {
            audioSource.PlayOneShot(Flashlight);
        }

        public void Play_Door_TryOpen()
        {
            audioSource.PlayOneShot(Door_TryOpen);
        }

        public void Play_Flashlight_Close()
        {
            audioSource.PlayOneShot(Flashlight);
        }


        public void Play_Player_Walk()
        {
            if (Time.time > LastTimeWalkSound + WalkSoundPeriod)
            {
                audioSourceWalk.pitch = UnityEngine.Random.Range(1, 1.5f);
                audioSourceWalk.Play();
                LastTimeWalkSound = Time.time;
                WalkSoundPeriod = UnityEngine.Random.Range(0.4f, 0.75f);
            }
        }

        private float LastTimeWalkSound = 0;
        private float WalkSoundPeriod = 0.5f;

        public void Play_DemonKilling()
        {
            audioSource.PlayOneShot(Audio_DemonKilling[UnityEngine.Random.Range(0, Audio_DemonKilling.Length)]);
        }

        public void Play_PriestShout()
        {
           // audioSourcePriest.Play(); - doesn't work if player skips the cut scene
           audioSourcePriest.gameObject.SetActive(true);
        }

        public void Play_LevelComplete_Sounds()
        {
            audioSource.PlayOneShot(Audio_Hit_With_Weapon);
            audioSource.PlayOneShot(Audio_Monster_Pain);
        }

        public void Play_Clown_Pain()
        {
            audioSource.PlayOneShot(Audio_Clown_Pain);
        }

        public void Play_Clown_Laugh()
        {
            foreach(AudioSource audioSource in audioSourceClownLaugh)
            {
                audioSource.gameObject.SetActive(true);
            }
        }
        public void Stop_Clown_Laugh()
        {
            foreach (AudioSource audioSource in audioSourceClownLaugh)
            {
                audioSource.gameObject.SetActive(false);
            }
        }
    }
}
