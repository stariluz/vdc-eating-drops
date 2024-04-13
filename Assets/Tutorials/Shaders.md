# Shaders in Unity

## Nodes in the shadergraph

We can found the nodes available in the shadergraph in the page [Nodes Library](https://docs.unity3d.com/Packages/com.unity.shadergraph@6.9/manual/Node-Library.html).

The nodes in the documentation are organised in the same way that the Create Node Menu.

### Artistic

#### Channel Mixer
It controls the ammount each of the channels of input *In* contribute each of the channels of output *Out*

##### Input.
In: Vector3

##### Outputs.
Out: Vector3

#### Controllers
The sliders control the contribution of the input channels, and the toggle buttons control which output channel will be affected, it can be just one or all of them.

#### Code explanation
This is a code example (that the documentation gave us) this node can generate. I'm adding a little explanation.
```cs
/**
 * These are the configurations of the node sliders and toggles. For example. If the toggle `R`
 * is active, it will be combined with the `G` slider value, to produce OutRedInGreen,
 * the same with the other two sliders.
 * 
 * If the toggle `B` was not active, then it will ignore the sliders values, 
 */
_ChannelMixer_Red = float3 (OutRedInRed, OutRedInGreen, OutRedInBlue);
_ChannelMixer_Green = float3 (OutGreenInRed, OutGreenInGreen, OutGreenInBlue);
_ChannelMixer_Blue = float3 (OutBlueInRed, OutBlueInGreen, OutBlueInBlue);

void Unity_ChannelMixer_float(float3 In, float3 _ChannelMixer_Red, float3 _ChannelMixer_Green, float3 _ChannelMixer_Blue, out float3 Out)
{
    /**
     * With dot(In, CHANNEL) we are getting the dot product of In and each ChannelMixer given by
     * the node controllers. 
     */
    Out = float3(dot(In, _ChannelMixer_Red), dot(In, _ChannelMixer_Green), dot(In, _ChannelMixer_Blue));
}
```