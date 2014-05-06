using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeadFirstDesignPattern.Facede.HomeTheater
{
    public class Amplifier
    {
        string description_;
        Tuner tuner_;
        CdPlayer cd_player_;
        DvdPlayer dvd_player_;

        public string Description
        {
            get { return description_; }
        }

        public Amplifier(string description)
        {
            description_ = description;
        }

        public string On()
        {
            return description_ + " on\n";
        }

        public string Off()
        {
            return description_ + " off\n";
        }

        public string SetStereoSound()
        {
            return description_ + " stereo mode on\n";
        }

        public string SetSurroundSound()
        {
            return description_ + " surround sound on (5 speakers, 1 subwoofer)\n";
        }

        public string SetVolume(int set_voleme)
        {
            description_ = string.Format("{0} setting volume to {1}\n", description_, set_voleme.ToString());
            return description_;
        }

        public string SetTuner(Tuner tuner_)
        {
            this.tuner_ = tuner_;
            description_ = string.Format("{0} setting tuner to {1}\n", description_, this.tuner_.Description);
            return description_;
        }

        public string SetDvd(DvdPlayer dvd_player_)
        {
            this.dvd_player_ = dvd_player_;
            description_ = string.Format("{0} setting DVD player to {1}\n", description_, this.dvd_player_.Description);
            return description_;
        }

        public string SetCd(CdPlayer cd_player_)
        {
            this.cd_player_ = cd_player_;
            description_ = string.Format("{0} setting CD player to {1}\n", description_, this.cd_player_.Description);
            return description_;
        }
    }

    public class Tuner
    {
        private string TurnerName;
        private Amplifier amplifier_;
        double frequency_;


        public Tuner(Amplifier amplifier_, string TurnerName)
        {
            this.amplifier_ = amplifier_;
            this.TurnerName = TurnerName;
            frequency_ = 0.0;
        }
        public string Description
        {
            get
            {
                return TurnerName;
            }
        }

        public string On()
        {
            return Description + " on\n";
        }

        public string Off()
        {
            return Description + " off\n";
        }

        public string SetFrequency(double frequency)
        {
            this.frequency_ = frequency;
            return string.Format("{0} setting frequency to {1}\n",Description , frequency.ToString());
        }

        public string SetAm()
        {
            return Description + " setting AM mode\n";
        }

        public string SetFm()
        {
            return Description + " setting FM mode\n";
        }
    }
    
    public class CdPlayer
    {
        private string description_;
        private Amplifier amplifier_;
        string title_;
        int current_track_;

        public CdPlayer(Amplifier amplifier_, string CdPlayerName)
        {
            this.amplifier_ = amplifier_;
            this.description_ = CdPlayerName;
            title_ = null;
            current_track_ = 0;
        }
        public string Description
        {
            get
            {
                return description_;
            }
        }

        public string Off()
        {
            return description_ + " off\n";
        }

        public string On()
        {
            return description_ + " on\n";
        }

        public string Eject()
        {
            title_ = null;
            return description_ + " eject\n";
        }

        public string Play(string title)
        {
            this.title_ = title;
            current_track_ = 0;
            return string.Format("{0} playing \"{1}\"\n",description_, title_);
        }

        public string Play(int track)
        {
            if (title_ == null)
            {
                return string.Format("{0} can't play track {1}, no cd inserted\n", description_, track);
            }
            else
            {
                current_track_ = track;
                return string.Format("{0} playing track {1}\n", description_, current_track_);
            }
        }

        public string Stop()
        {
            current_track_ = 0;
            return description_ + " stopped\n";
        }

        public string Pause()
        {
            return string.Format("{0} paused \"{1}\"\n", description_, title_);
        }
    }
    
    public class DvdPlayer
    {
        private string DvdPlayerName;
        private Amplifier amplifier_;
        string movie_;
        int current_track_;

        public DvdPlayer(Amplifier amplifier_, string DvdPlayerName)
        {
            this.amplifier_ = amplifier_;
            this.DvdPlayerName = DvdPlayerName;
            movie_ = null;
            current_track_ = 0;
        }
        public string Description
        {
            get
            {
                return DvdPlayerName;
            }
        }

        public string On()
        {
            return Description + " on\n";
        }

        public string Off()
        {
            return Description + " off\n";
        }

        public string Eject()
        {
            movie_ = null;
            return Description + " eject\n";
        }

        public string Play(string movie)
        {
            this.movie_ = movie;
            current_track_ = 0;
            return string.Format("{0} playing \"{1}\"\n",Description , movie_);
        }

        public string Play(int track)
        {
            if (movie_ == null)
            {
                return string.Format("{0} can't play track {1} no dvd inserted\n", Description, track.ToString());
            }
            else
            {
                current_track_ = track;
                return string.Format("{0} playing track {1} of \"{2}\"\n", Description, current_track_.ToString(), movie_);
            }
        }

        public string Stop()
        {
            current_track_ = 0;
            return string.Format("{0} stopped \"{1}\"\n", Description, movie_);
        }

        public string Pause()
        {
            return string.Format("{0} paused \"{1}\"\n", Description, movie_);
        }

        public string SetTwoChannelAudio()
        {
            return Description + " set two channel audio\n";
        }

        public string SetSurroundAudio()
        {
            return Description + " set surround audio\n";
        }
    }

    public class Projector
    {
        string description_;
        DvdPlayer dvd_player_;

        public string Description
        {
            get { return description_; }
        }

        public Projector(string description, DvdPlayer dvdPlayer)
        {
            this.description_ = description;
            this.dvd_player_ = dvdPlayer;
        }

        public string On()
        {
            return description_ + " on\n";
        }

        public string Off()
        {
            return description_ + " off\n";
        }

        public string WideScreenMode()
        {
            return description_ + " in widescreen mode (16x9 aspect ratio)\n";
        }

        public string TvMode()
        {
            return description_ + " in tv mode (4x3 aspect ratio)\n";
        }
    }

    public class TheaterLights
    {
        string description_;

        public string Description
        {
            get { return description_; }
        }

        public TheaterLights(string description)
        {
            this.description_ = description;
        }

        public string On()
        {
            return description_ + " on\n";
        }

        public string Off()
        {
            return description_ + " off\n";
        }

        public string Dim(int level)
        {
            return string.Format("{0} dimming to {1}%\n", description_, level.ToString());
        }
    }

    public class PopcornPopper
    {
        string description_;

        public string Description
        {
            get { return description_; }
        }

        public PopcornPopper(string description)
        {
            this.description_ = description;
        }

        public string On()
        {
            return description_ + " on\n";
        }

        public string Off()
        {
            return description_ + " off\n";
        }

        public string Pop()
        {
            return description_ + " popping popcorn!\n";
        }
    }

    public class Screen
    {
        string description_;

        public string Description
        {
            get { return description_; }
        }

        public Screen(string description)
        {
            this.description_ = description;
        }

        public string Up()
        {
            return description_ + " going up\n";
        }

        public string Down()
        {
            return description_ + " going down\n";
        }
    }

    public class HomeTheaterFacade
    {
        Amplifier amplifier_;
        Tuner tuner_;
        DvdPlayer dvd_player_;
        CdPlayer cd_player_;
        Projector projector_;
        TheaterLights theater_lights_;
        Screen screen_;
        PopcornPopper popcorn_popper_;

        public HomeTheaterFacade(Amplifier amp, Tuner tuner, DvdPlayer dvd, CdPlayer cd, Projector projector, Screen screen, TheaterLights lights, PopcornPopper popper)
        {
            this.amplifier_ = amp;
            this.tuner_ = tuner;
            this.dvd_player_ = dvd;
            this.cd_player_ = cd;
            this.projector_ = projector;
            this.screen_ = screen;
            this.theater_lights_ = lights;
            this.popcorn_popper_ = popper;
        }

        public string WatchMovie(string movie)
        {
            StringBuilder watch_movie_string = new StringBuilder();

            watch_movie_string.Append("Get ready to watch a movie...\n");
            watch_movie_string.Append(popcorn_popper_.On());
            watch_movie_string.Append(popcorn_popper_.Pop());
            watch_movie_string.Append(theater_lights_.Dim(10));
            watch_movie_string.Append(screen_.Down());
            watch_movie_string.Append(projector_.On());
            watch_movie_string.Append(projector_.WideScreenMode());
            watch_movie_string.Append(amplifier_.On());
            watch_movie_string.Append(amplifier_.SetDvd(dvd_player_));
            watch_movie_string.Append(amplifier_.SetSurroundSound());
            watch_movie_string.Append(amplifier_.SetVolume(5));
            watch_movie_string.Append(dvd_player_.On());
            watch_movie_string.Append(dvd_player_.Play(movie));

            return watch_movie_string.ToString();
        }

        public string EndMovie()
        {
            StringBuilder end_movie_string = new StringBuilder();

            end_movie_string.Append("Shutting movie theater down...\n");
            end_movie_string.Append(popcorn_popper_.Off());
            end_movie_string.Append(theater_lights_.On());
            end_movie_string.Append(screen_.Up());
            end_movie_string.Append(projector_.Off());
            end_movie_string.Append(amplifier_.Off());
            end_movie_string.Append(dvd_player_.Stop());
            end_movie_string.Append(dvd_player_.Eject());
            end_movie_string.Append(dvd_player_.Off());

            return end_movie_string.ToString();
        }

        public string ListenToCd(string cd_player_Title)
        {
            StringBuilder listen_to_cd_string = new StringBuilder();

            listen_to_cd_string.Append("Get ready for an audio experence...\n");
            listen_to_cd_string.Append(theater_lights_.On());
            listen_to_cd_string.Append(amplifier_.On());
            listen_to_cd_string.Append(amplifier_.SetVolume(5));
            listen_to_cd_string.Append(amplifier_.SetCd(cd_player_));
            listen_to_cd_string.Append(amplifier_.SetStereoSound());
            listen_to_cd_string.Append(cd_player_.On());
            listen_to_cd_string.Append(cd_player_.Play(cd_player_Title));

            return listen_to_cd_string.ToString();
        }

        public string EndCd()
        {
            StringBuilder end_cd_string = new StringBuilder();

            end_cd_string.Append("Shutting down CD...\n");
            end_cd_string.Append(amplifier_.Off());
            end_cd_string.Append(amplifier_.SetCd(cd_player_));
            end_cd_string.Append(cd_player_.Eject());
            end_cd_string.Append(cd_player_.Off());

            return end_cd_string.ToString();
        }

        public string ListenToRadio(double frequency)
        {
            StringBuilder listen_to_radio_string = new StringBuilder();

            listen_to_radio_string.Append("Tuning in the airwaves...\n");
            listen_to_radio_string.Append(tuner_.On());
            listen_to_radio_string.Append(tuner_.SetFrequency(frequency));
            listen_to_radio_string.Append(amplifier_.On());
            listen_to_radio_string.Append(amplifier_.SetVolume(5));
            listen_to_radio_string.Append(amplifier_.SetTuner(tuner_));

            return listen_to_radio_string.ToString();
        }

        public string EndRadio()
        {
            StringBuilder end_radio_string = new StringBuilder();

            end_radio_string.Append("Shutting down the tuner_...\n");
            end_radio_string.Append(tuner_.Off());
            end_radio_string.Append(amplifier_.Off());

            return end_radio_string.ToString();
        }
    }
}
