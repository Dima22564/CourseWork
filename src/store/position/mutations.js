/*
export function someMutation (state) {
}
*/

export function setAll (state, data) {
  state.positions = data
}

export function add (state, data) {
  state.partners.push(data)
}
