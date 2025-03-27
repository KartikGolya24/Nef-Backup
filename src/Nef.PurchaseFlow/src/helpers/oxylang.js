const oxy = {

  oxylang(OxygenLangKey, key) {

    //const OxygenLang = window.oxygen[OxygenLangKey];
    //if (!OxygenLang) {
    //  return;
    //}

    return window.oxygen[key] || `[${key}]`;
  }
}
export default oxy
