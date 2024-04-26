using AutoMapper;
using System.Reflection;

namespace TaskBoard.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ApplyMappingsFromAssembly(Assembly.GetAssembly(typeof(MappingProfile)));
        }

        private void ApplyMappingsFromAssembly(Assembly assembly)
        {
            var types = assembly.GetExportedTypes()
                .Where(t => t.GetInterfaces().Any(i =>
                    i.IsGenericType && (i.GetGenericTypeDefinition() == typeof(IMapFrom<>) ||
                                        i.GetGenericTypeDefinition() == typeof(IMapTo<>))))
                .ToList();

            foreach (var type in types)
            {
                var instance = Activator.CreateInstance(type);

                var mapTo = type.GetMethod("MapTo") ??
                            instance!.GetType()
                                .GetInterface("IMapTo`1")?
                                .GetMethod("MapTo");

                var mapFrom = type.GetMethod("MapFrom") ??
                              instance!.GetType()
                                  .GetInterface("IMapFrom`1")?
                                  .GetMethod("MapFrom");

                mapTo?.Invoke(instance, new object[] { this });
                mapFrom?.Invoke(instance, new object[] { this });
            }
        }
    }
}
