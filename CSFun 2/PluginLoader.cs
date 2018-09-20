using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using CSFun2.Plugin;

namespace CSFun2 {
	public class PluginLoader {
		public List<ISub> plugins;
		private string pluginsDir = Properties.Settings.Default.PluginsDir;

		public ICollection<ISub> LoadPlugins() {
			Console.WriteLine("Loading plugins...");
			plugins = new List<ISub>();
			
			if (Directory.Exists(pluginsDir)) {
				string[] files = Directory.GetFiles(pluginsDir, "*.dll");
				ICollection<Assembly> assemblies = new List<Assembly>(files.Length);
				foreach (string file in files) {
					if (file.EndsWith(".dll")) {
						AssemblyName an = AssemblyName.GetAssemblyName(file);
						Assembly assembly = Assembly.Load(an);
						assemblies.Add(assembly);
					}
				}

				Type interfaceType = typeof(ISub);
				ICollection<Type> pluginTypes = new List<Type>();
				foreach (Assembly assembly in assemblies) {
					if (assembly != null) {
						Type[] types = assembly.GetTypes();
						foreach (Type type in types) {
							if (type.IsInterface || type.IsAbstract) {
								continue;
							} else {
								if (type.GetInterface(interfaceType.FullName) != null) {
									pluginTypes.Add(type);
								}
							}
						}
					}
				}

				foreach (Type type in pluginTypes) {
					ISub plugin = (ISub)Activator.CreateInstance(type);
					plugins.Add(plugin);
				}

				return plugins;
			} else {
				Console.WriteLine("Plugins directory doesn't exist.");
			}
			return null;
		}

		public ISub LoadPlugin(string fileName) {
			string file = pluginsDir + "\\" + fileName;
			if (Directory.Exists(pluginsDir)) {
				if (file.EndsWith(".dll")) {
					AssemblyName an = AssemblyName.GetAssemblyName(file);
					Assembly assembly = Assembly.Load(an);

					Type interfaceType = typeof(ISub);
					if (assembly != null) {
						Type[] types = assembly.GetTypes();
						foreach (Type type in types) {
							if (type.IsInterface || type.IsAbstract) {
								continue;
							} else {
								if (type.GetInterface(interfaceType.FullName) != null) {
									ISub plugin = (ISub)Activator.CreateInstance(type);
									return plugin;
								}
							}
						}
					} else {
						Console.WriteLine("Assembly is null.");
					}
				}
			}
			return null;
		}
	}
}
