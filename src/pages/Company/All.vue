<template>
  <q-page padding>
    <q-table
      title="Зарегистрированные компании"
      :data="data"
      :columns="columns"
      row-key="name"
      binary-state-sort
      :loading="loading"
    >
      <template v-slot:body="props">
        <q-tr :props="props">
          <q-td key="name" :props="props">
            {{ props.row.name }}
            <q-popup-edit
              v-model="props.row.name"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.name" dense autofocus counter />
            </q-popup-edit>
          </q-td>
          <q-td key="abbreviation" :props="props">
            {{ props.row.abbreviation }}
            <q-popup-edit
              v-model="props.row.abbreviation"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.abbreviation" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="email" :props="props">
            {{ props.row.email }}
            <q-popup-edit
              v-model="props.row.email"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.email" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="email" :props="props">
            {{ props.row.tin }}
            <q-popup-edit
              v-model="props.row.tin"
              :buttons="true"
              label-set="Обновить"
              label-cancel="Отмена"
            >
              <q-input v-model="props.row.tin" dense autofocus />
            </q-popup-edit>
          </q-td>
          <q-td key="saveChanges" :props="props">
            <q-btn color="primary" size="sm" label="Сохранить" @click="saveChanges(props.row.tin)" :loading="loading" />
            <q-btn class="q-ml-sm" color="secondary" size="sm" label="Просмотр" @click="loadCompany(props.row.tin)" :loading="loading" />
            <q-btn class="q-ml-sm" :icon="mdiPlus" color="purple" size="sm" label="сотрудника" @click="employee = true" :loading="loading" />
          </q-td>
        </q-tr>

        <q-dialog v-model="employee" persistent>
          <q-card style="width: 450px;">
            <q-card-section class="row items-center justify-between">
              <span class="q-ml-sm text-h6">Добавить сотрудника.</span>
              <q-btn size="md" color="amber" @click="createEmployee = true" glossy label="Создать" />
            </q-card-section>

            <AddEmployeePopup />

            <q-card-actions align="right">
              <q-btn flat label="Закрыть" color="primary" v-close-popup />
            </q-card-actions>
          </q-card>
        </q-dialog>

        <q-dialog v-model="createEmployee" persistent>
          <q-card style="width: 700px;">
            <q-card-section class="row items-center justify-between">
              <span class="q-ml-sm">Мастер создания сотрудника.</span>
            </q-card-section>

            <CreateEmployeePopup />

            <q-card-actions align="right">
              <q-btn flat label="Закрыть" color="primary" v-close-popup />
            </q-card-actions>
          </q-card>
        </q-dialog>

      </template>
    </q-table>
  </q-page>
</template>

<script>
import { mdiPlus } from '@quasar/extras/mdi-v5'
import AddEmployeePopup from 'components/addingElements/AddEmployeePopup'
import CreateEmployeePopup from 'components/creationElements/CreateEmployeePopup'
export default {
  name: 'PageCompanyAll',
  components: {
    AddEmployeePopup,
    CreateEmployeePopup
  },
  methods: {
    saveChanges (tin) {
      this.loading = true
      // /company/change/tin
    },
    loadCompany (tin) {
      this.$router.push('/company/' + tin)
    }
  },
  data: () => {
    return {
      loading: false,
      mdiPlus,
      employee: false,
      createEmployee: false,
      data: [
        { name: 'JJJJddfdf', abbreviation: 'DFGA', email: 'email@exp.rt', tin: 221651, saveChanges: '' },
        { name: 'JJJJddfdf', abbreviation: 'DFGA', email: 'email@exp.rt', tin: 221651, saveChanges: '' }
      ],
      columns: [
        {
          name: 'name',
          label: 'Название',
          align: 'left',
          field: 'name'
        },
        { name: 'abbreviation', label: 'Соращенное название', field: 'abbreviation' },
        { name: 'email', label: 'Email', field: 'email' },
        { name: 'tin', label: 'Инн', field: 'tin' },
        { name: 'saveChanges', label: '', field: 'saveChanges' }
      ]
    }
  }
}
</script>
