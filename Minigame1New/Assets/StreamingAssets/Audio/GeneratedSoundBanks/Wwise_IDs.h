/////////////////////////////////////////////////////////////////////////////////////////////////////
//
// Audiokinetic Wwise generated include file. Do not edit.
//
/////////////////////////////////////////////////////////////////////////////////////////////////////

#ifndef __WWISE_IDS_H__
#define __WWISE_IDS_H__

#include <AK/SoundEngine/Common/AkTypes.h>

namespace AK
{
    namespace EVENTS
    {
        static const AkUniqueID BOATACCEL = 2966425545U;
        static const AkUniqueID BOATANGLE = 28419968U;
        static const AkUniqueID BOATCOLLISION = 3905425309U;
        static const AkUniqueID BOATENGINE = 3434945777U;
        static const AkUniqueID CHECKPOINTCHECK = 1390999685U;
        static const AkUniqueID CHECKPOINTSHIMMER = 1309997348U;
        static const AkUniqueID MUSICMAIN = 374987273U;
        static const AkUniqueID OBSTACLES_CLAYHIT = 2521554274U;
        static const AkUniqueID OBSTACLES_SEAURCHINHIT = 1213636067U;
        static const AkUniqueID OBSTACLESDISTANCE = 176106368U;
    } // namespace EVENTS

    namespace STATES
    {
        namespace DISTANCETOCHECKPOINT
        {
            static const AkUniqueID GROUP = 1298537561U;

            namespace STATE
            {
                static const AkUniqueID CLOSER = 3012222967U;
                static const AkUniqueID CLOSEST = 2577305654U;
                static const AkUniqueID FAR = 1183803292U;
            } // namespace STATE
        } // namespace DISTANCETOCHECKPOINT

    } // namespace STATES

    namespace SWITCHES
    {
        namespace MUSIC_SWELLS_CALM
        {
            static const AkUniqueID GROUP = 2267824967U;

            namespace SWITCH
            {
            } // namespace SWITCH
        } // namespace MUSIC_SWELLS_CALM

    } // namespace SWITCHES

    namespace GAME_PARAMETERS
    {
        static const AkUniqueID BOATSPEED = 659411096U;
        static const AkUniqueID BOATTURNANGLE = 173832523U;
        static const AkUniqueID DISTANCETOCHECKPOINT = 1298537561U;
        static const AkUniqueID DISTANCETOGOLEM = 208146177U;
        static const AkUniqueID DISTANCETONEARESTOBSTACLE = 2528135412U;
    } // namespace GAME_PARAMETERS

    namespace BANKS
    {
        static const AkUniqueID INIT = 1355168291U;
        static const AkUniqueID MUSIC = 3991942870U;
        static const AkUniqueID SFX = 393239870U;
    } // namespace BANKS

    namespace BUSSES
    {
        static const AkUniqueID MASTER_AUDIO_BUS = 3803692087U;
    } // namespace BUSSES

    namespace AUDIO_DEVICES
    {
        static const AkUniqueID NO_OUTPUT = 2317455096U;
        static const AkUniqueID SYSTEM = 3859886410U;
    } // namespace AUDIO_DEVICES

}// namespace AK

#endif // __WWISE_IDS_H__
