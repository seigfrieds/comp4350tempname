//pattern idea: can just wraps a fetch call.. then the .vue components dont really have to worry about making API calls -> they just call the service function
const getPotholeIncident = () => {
  // return fetch("/potholeIncident");
  return 1;
};

export { getPotholeIncident };
