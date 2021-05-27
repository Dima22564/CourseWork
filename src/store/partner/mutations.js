/*
export function someMutation (state) {
}
*/

export function setAll (state, data) {
  state.partners = data
}

export function add (state, data) {
  state.partners.push(data)
}
