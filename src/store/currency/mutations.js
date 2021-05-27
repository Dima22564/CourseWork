/*
export function someMutation (state) {
}
*/

export function setAll (state, data) {
  state.currencies = data
}

export function updateCurrency (state, data) {
  const currency = state.currencies.find(x => x.numericCode === data.code)
  currency[data.propName] = data.val
}
