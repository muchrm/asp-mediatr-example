using System.Runtime.Serialization;
using MediatR;

namespace asp_mediatr_example.Commands;

[DataContract]
public class HelloNotification : INotification{
    [DataMember]
    public string Name {get;init;}
    public HelloNotification(string name){
        this.Name = name;
    }
}