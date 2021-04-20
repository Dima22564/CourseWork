<template>
  <div class="q-pa-lg">
    <q-list bordered class="rounded-borders" >
      <q-item-label header>Все сотрудники</q-item-label>

      <q-item :class="{ 'bg-green-3': checkIfChecked(2) }">
        <q-item-section top>
          <q-item-label lines="1">
            <span class="text-weight-medium">Иванов Иван Иванович</span>
            <span class="text-grey-8"> - email@ewf.rt</span>
          </q-item-label>
          <q-item-label lines="1">
            <span class="text-weight-medium">Position</span>
            <span class="text-grey-8"> - position</span>
          </q-item-label>
          <q-item-label lines="1">
            <span class="text-weight-medium">Компания</span>
            <span class="text-grey-8"> - ОООООООООООООО</span>
          </q-item-label>
          <q-item-label lines="1" class="q-mt-xs text-body2 text-weight-bold text-primary text-uppercase">
            <router-link class="q-link cursor-pointer text-primary" :to="'/employee/' + 123165">Подробнее</router-link>
          </q-item-label>
        </q-item-section>

        <q-item-section top side>
          <div class="text-grey-8 q-gutter-xs">
            <q-btn class="gt-xs" size="12px" flat dense round icon="done" @click="add(2)" />
          </div>
        </q-item-section>
      </q-item>

      <q-separator spaced />

    </q-list>

    <q-btn flat label="Добавить" color="primary" class="q-ml-auto flex q-mt-sm" />
  </div>
</template>

<script>
export default {
  data: () => {
    return {
      checkedEmployees: []
    }
  },
  methods: {
    add (id) {
      if (this.checkIfChecked(id)) {
        this.checkedEmployees.splice(this.checkedEmployees.indexOf(id), 1)
      } else {
        this.checkedEmployees.push(id)
      }
    },
    checkIfChecked (id) {
      return this.checkedEmployees.includes(id)
    }
  }
}
</script>
