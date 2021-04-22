<template>
  <div class="q-pa-lg">
    <q-table
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
      no-data-label="Нет данных"
      flat
    >
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="tin" :props="props">
            {{ props.row.tin }}
          </q-td>

          <q-td key="name" :props="props">
            {{ props.row.name }}
          </q-td>

          <q-td key="email" :props="props">
            {{ props.row.email }}
          </q-td>

          <q-td key="phone" :props="props">
            {{ props.row.phone }}
          </q-td>

          <q-td key="actions" :props="props">
            <q-btn :disable="responsiblePerson !== null" :to="'/marketing/view/order/' + props.row.orderId" class="q-mr-sm" color="secondary" size="sm" :icon="icons.mdiMagnify" :loading="loading" />
            <q-btn :disable="responsiblePerson !== null" @click="selectPerson(props.row.contactPersonId)" class="q-mr-sm" color="positive" size="sm" :icon="icons.mdiCheck" :loading="loading">
              <q-tooltip>Назначить на согласование</q-tooltip>
            </q-btn>
            <q-btn :disable="responsiblePerson === null" @click="deleteSelected" color="negative" size="sm" :icon="icons.mdiDelete" :loading="loading">
              <q-tooltip>Отменить назначение</q-tooltip>
            </q-btn>
          </q-td>
        </q-tr>
      </template>
    </q-table>

    <div class="flex justify-end">
      <q-btn :disable="!responsiblePerson" class="q-mt-md q-mr-sm q-ml-auto" @click="saveSelected" color="primary" size="md" label="Подтвердить" :loading="loading">
        <q-tooltip>Подтвердить</q-tooltip>
      </q-btn>
      <q-btn :disable="responsiblePerson === null" class="q-mt-md" @click="deleteSelected" color="negative" size="md" label="Сбросить" :loading="loading">
        <q-tooltip>Сбросить</q-tooltip>
      </q-btn>
    </div>

  </div>
</template>

<script>
import icons from 'src/mixins/icons'

export default {
  name: 'SelectResponsiblePerson',
  mixins: [icons],
  props: {
    data: {
      type: Array,
      default: () => [{}]
    }
  },
  data: () => {
    return {
      loading: false,
      responsiblePerson: null,
      selectResponsiblePerson: false,
      columns: [
        { name: 'tin', label: 'ИНН', align: 'left', field: 'tin' },
        { name: 'name', label: 'ФИО', field: 'name' },
        { name: 'email', label: 'Email', field: 'email' },
        { name: 'phone', label: 'Тел.', field: 'validTo' },
        { name: 'actions', label: 'Действия', field: 'actions' }
      ]
    }
  },
  methods: {
    deleteSelected () {
      this.responsiblePerson = null
    },
    saveSelected () {

    },
    selectPerson (contactPersonId) {
      this.responsiblePerson = 'dfds'
    }
  }
}
</script>
