using System.Runtime.Serialization;
using MediatR;

namespace asp_mediatr_example.Commands;

[DataContract]
public class HelloCommand : IRequest<bool>{
    [DataMember]
    public string Name {get;init;}
    public HelloCommand(string name){
        this.Name = name;
    }
}