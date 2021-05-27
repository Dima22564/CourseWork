export function setAll (state, data) {
  state.countries = data
}

export function updateCountry (state, data) {
  const country = state.countries.find(x => x.code === data.code)
  country[data.propName] = data.val
}
