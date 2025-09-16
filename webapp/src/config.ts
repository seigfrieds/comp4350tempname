//PATTERN IDEA: don't have to do import.meta.env everywhere
//- just do it all here, then all other files can import the config for configuration options

//POSSIBILITY: could have a config validator somehow? so if your config is wrong format you know right on app startup

const config = {
  example: import.meta.env.VITE_EXAMPLE,
};

export default config;
