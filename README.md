# Ra3MapBridge

This project is forked from [Ra3Solution/MapCoreLib](https://github.com/RA3MapLab/Ra3Solution/tree/master/MapCoreLib), and serves as a subproject of [ra3map_python](https://github.com/dreamness-dnalm/ra3map_python), acting as an architectural foundation.  

## Parts
### MapCoreLibMod
This part is forked from [Ra3Solution/MapCoreLib](https://github.com/RA3MapLab/Ra3Solution/tree/master/MapCoreLib)  
modification:  
- switch compile target to .NET 6.0 from .NET Framework 3.5
- remove some unnecessary files for invoked by ra3map_python, such as Core/Scripts, Core/Util/EditorHelper.cs, etc.  
- modify some code for compatibility with invoked by ra3map_python
- modify some other logic, about waypoint, worldinfo, etc.

### Ra3MapBridge
This part is a wrapper for MapCoreLibMod, which will be called by the ra3map_python project. 


## Thanks
@wu162